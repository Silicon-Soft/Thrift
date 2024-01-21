using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Security.Claims;
using Thrift_Us.Data;
using Thrift_Us.Models;
using Thrift_Us.Status;
using Thrift_Us.ViewModel;

namespace Thrift_Us.Controllers
{
    /* [Authorize(Roles = "Admin")]*/
    public class OrderController : Controller
    {
        private readonly ThriftDbContext _context;
        public OrderController(ThriftDbContext context)
        {
            _context = context;

        }
        public IActionResult Index(string status)
        {
            IEnumerable<OrderHeader> orderHeaders = Enumerable.Empty<OrderHeader>();

            if (User.IsInRole("Admin") || User.IsInRole("Seller"))
            {
                orderHeaders = _context.OrderHeaders.Include(x => x.ApplicationUser);
            }
            else
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

                if (claim != null)
                {
                    orderHeaders = _context.OrderHeaders.Where(x => x.ApplicationUserId == claim.Value);
                }
            }


            orderHeaders = status switch
            {
                "pending" => orderHeaders.Where(x => x.PaymentStatus == PaymentStatus.StatusPending),
                "approved" => orderHeaders.Where(x => x.PaymentStatus == PaymentStatus.StatusApproved),
                "underprocess" => orderHeaders.Where(x => x.OrderStatus == OrderStatus.StatusInProcess),
                "shipped" => orderHeaders.Where(x => x.OrderStatus == OrderStatus.StatusShipped),
                _ => orderHeaders
            };

            var orderHeadersList = orderHeaders.ToList();
            if (orderHeadersList == null || !orderHeadersList.Any())
            {
                orderHeadersList = new List<OrderHeader>();
            }
            return View(orderHeadersList);
        }


        public async Task<IActionResult> OrderDetails(int id)
        {
            var orderHeader = await _context.OrderHeaders
                .Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (orderHeader == null || orderHeader.ApplicationUser == null)
            {

                return NotFound();
            }


            var orderDetails = await _context.OrderDetails
                .Include(x => x.Product)
                .Where(x => x.OrderHeaderId == id)
                .ToListAsync();

            var orderDetailsViewModel = new OrderDetailsViewModel
            {
                OrderHeader = orderHeader,
                OrderDetails = orderDetails
            };

            return View(orderDetailsViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> SaveOrder(CartOrderViewModel cartorderviewmodel)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                double orderTotal = 0;
                foreach (var cartItem in cartorderviewmodel.ListOfCart)
                {
                    orderTotal += cartItem.Count * cartItem.Product.Price;

                }
                /*   ViewBag.PaymentStatus = new List<SelectListItem>
                   {
                       new SelectListItem { Value = PaymentStatus.StatusPending, Text = PaymentStatus.StatusPending },
                       new SelectListItem { Value = PaymentStatus.StatusApproved, Text = PaymentStatus.StatusApproved },
                       new SelectListItem { Value = PaymentStatus.StatusRejected, Text = PaymentStatus.StatusRejected },
                       new SelectListItem { Value = PaymentStatus.StatusPayementDelayed, Text = PaymentStatus.StatusPayementDelayed }
                   };
                   ViewBag.OrderStatus = new List<SelectListItem>
                   {
                       new SelectListItem { Value = OrderStatus.StatusPending, Text = OrderStatus.StatusPending },

                       new SelectListItem { Value = OrderStatus.StatusApproved, Text = OrderStatus.StatusApproved },
                       new SelectListItem { Value = OrderStatus.StatusCancelled, Text = OrderStatus.StatusCancelled },
                       new SelectListItem { Value = OrderStatus.StatusInProcess, Text = OrderStatus.StatusInProcess },
                       new SelectListItem { Value = OrderStatus.StatusShipped, Text = OrderStatus.StatusShipped }
                   };
                   var paymentStatus = model.OrderHeader.PaymentStatus;
                   var orderStatus = model.OrderHeader.OrderStatus;*/
                var orderHeader = new OrderHeader
                {
                    ApplicationUserId = claim.Value,
                    Name = cartorderviewmodel.OrderHeader.Name,
                    Phone = cartorderviewmodel.OrderHeader.Phone,
                    Address = cartorderviewmodel.OrderHeader.Address,
                    City=cartorderviewmodel.OrderHeader.City,
                    State =cartorderviewmodel.OrderHeader.State,
                    PostalCode=cartorderviewmodel.OrderHeader.PostalCode,
                    DateofPick = cartorderviewmodel.OrderHeader.DateofPick,
                    TimeofPick = cartorderviewmodel.OrderHeader.TimeofPick,
                    OrderDate=cartorderviewmodel.OrderHeader.OrderDate,
                    OrderTotal = orderTotal,
                    OrderStatus = "Pending",
                    PaymentStatus="Pending",
                    TransId=GenerateTransactionId()
                };

                _context.OrderHeaders.Add(orderHeader);
                await _context.SaveChangesAsync();

                if (cartorderviewmodel.ListOfCart != null && cartorderviewmodel.ListOfCart.Any())
                {
                    foreach (var cartItem in cartorderviewmodel.ListOfCart)
                    {
                        var orderDetail = new OrderDetails
                        {
                            ProductId = cartItem.ProductId,
                            Count = cartItem.Count,
                            Description = "Good",
                            Name=cartItem.Product.ProductName,
                            Price = cartItem.Product.Price
                        };

                        _context.OrderDetails.Add(orderDetail);
                        await _context.SaveChangesAsync();

                        var cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == cartItem.Id);
                        if (cart != null)
                        {
                            _context.Carts.Remove(cart);
                        }
                    }

                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return RedirectToAction("Index");
            }


            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                var orderHeaders = _context.OrderHeaders.ToList();
                return View("Index", orderHeaders);

            }
        }

        private string GenerateTransactionId()
        {

            return Guid.NewGuid().ToString();
        }


    }
}

