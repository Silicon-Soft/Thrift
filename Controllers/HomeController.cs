using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Thrift_Us.Data;
using Thrift_Us.Models;
using Thrift_Us.Services.Interface;
using Thrift_Us.ViewModel;
using Thrift_Us.ViewModels;

namespace Thrift_Us.Controllers
{
    public class HomeController : Controller
    {
        private readonly ThriftDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService,ThriftDbContext context)
        {
            _logger = logger;
            _productService=productService;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts().OrderByDescending(Product =>Product.ProductId); 
            return View(products);
        }
        public IActionResult Product()
        {
            var products = _productService.GetAllProducts().OrderByDescending(Product => Product.ProductId);
            return View(products);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int Id)
        {
            var product=await _context.Products.Include(x=>x.Category).
                Where(x=>x.ProductId==Id).FirstOrDefaultAsync();
            var cart = new CartViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Size = product.Size,
                ImageUrl = product.ImageUrl,
                Condition = product.Condition,
                Count=1

            };
            return View(cart);
        }

        [HttpPost]
        [Authorize(Roles = "Buyer")]
        public async Task<IActionResult> Details(CartViewModel cartViewModel)
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    _logger.LogWarning("User ID is null in AddToCart");
                    return RedirectToAction("Login", "Account");
                }

                var product = await _context.Products
                    .Include(x => x.Category)
                    .Where(x => x.ProductId == cartViewModel.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {cartViewModel.ProductId} not found.");
                    return NotFound();
                }

                var existingCartItem = await _context.Carts
                    .FirstOrDefaultAsync(c => c.ApplicationUserId == userId && c.ProductId == cartViewModel.ProductId);

                if (existingCartItem == null)
                {
                    var newCartItem = new Cart
                    {
                        ApplicationUserId = userId,
                        ProductId = cartViewModel.ProductId,
                        Count = cartViewModel.Count
                    };

                    _context.Carts.Add(newCartItem);
                }
                else
                {
                    existingCartItem.Count += cartViewModel.Count;
                }

                await _context.SaveChangesAsync();
                var Count = _context.Carts.Where(x => x.ApplicationUserId == userId).ToList().Count();

                HttpContext.Session.SetInt32("SessionCart", Count);
               
                return RedirectToAction("Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddToCart");
                return RedirectToAction("Error", "Home");
            }

        }
        [AllowAnonymous]
        public async Task<IActionResult> Rent(int Id)
        {
            var product = await _context.Products.FindAsync(Id);

            if (product == null)
            {
                return NotFound();
            }

            var rental = new List<RentalViewModel>()
            {
                new RentalViewModel()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    RentalPrice = product.RentalPrice,
                    Size = product.Size,
                    ImageUrl = product.ImageUrl,
                    Condition = product.Condition,
               
                }
            };

            return View(rental);
        }

        [HttpPost]
        [Authorize(Roles = "Buyer")]
        public async Task<IActionResult> Rent(RentalViewModel model)
        {
           
            
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    _logger.LogWarning("User ID is null in Rent");
                    return RedirectToAction("Login", "Account");
                }

                var product = await _context.Products
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.ProductId == model.ProductId);

                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {model.ProductId} not found.");
                    return NotFound();
                }
            decimal totalPrice = product.RentalPrice * model.RentalDuration;

            var rental = new Rental
                {
                    ProductId = model.ProductId,
                    ApplicationUserId = userId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    TotalPrice = totalPrice,
                    RentalDuration = model.RentalDuration
                };

                _context.Rentals.Add(rental);
                await _context.SaveChangesAsync();

            
              

                var rentalCartItem = new RentalCart
                {
                    ApplicationUserId = userId,
                    ProductId= model.ProductId,
                    Count = model.Count
                };

                _context.RentalCarts.Add(rentalCartItem);
                await _context.SaveChangesAsync();

                var rentalCartCount = _context.RentalCarts.Count(c => c.ApplicationUserId == userId);
                HttpContext.Session.SetInt32("SessionRental", rentalCartCount);
            ViewBag.TotalPrice = totalPrice;
            return RedirectToAction("Rent");
            
          
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}