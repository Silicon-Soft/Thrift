
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thrift_Us.Data;
using Microsoft.AspNetCore;
using Thrift_Us.ViewModel.Product;
using System.Net;
using System.Drawing;
using Thrift_Us.Models;
using Thrift_Us.ViewModel.Category;

namespace Thrift_Us.Controllers
{
    public class ProductController : Controller
    {
        private readonly ThriftDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ThriftDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment= webHostEnvironment;
        }
        public IActionResult Index()
        {
            var productItems = _context.Products.AsNoTracking()
                .Include(x => x.Category)
                .Select(x => new ProductIndexViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    Price = x.Price,
                    Size = x.Size,
                    Condition = x.Condition,
                    ImageUrl=x.ImageUrl,
                    PostedOn = x.PostedOn
                }).ToList();

            return View(productItems);
        }
        [HttpGet]

        public IActionResult Create()
        {
            var viewModel = new ProduceCreateViewModel
            {

                Categories = _context.Categories
             .Select(c => new CategoryCreateViewModel
             {
                 CategoryId = c.CategoryId,
                 CategoryName = c.CategoryName
             }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProduceCreateViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string stringFileName = UploadFile(vm);
                    var product = new Product()
                    {
                        ProductName = vm.ProductName,
                        Description = vm.Description,
                        CategoryId = vm.CategoryId,
                        Price = vm.Price,
                        Size = vm.Size,
                        ImageUrl = stringFileName,
                        Condition = vm.Condition,
                        PostedOn = DateTime.Now
                    };

                    _context.Products.Add(product);
                    _context.SaveChanges();

                   
                    return RedirectToAction("Index");
                }
                else

                {
                    ModelState.AddModelError(string.Empty, "Model property is not valid, please chaeck");
                }
               
            }
            catch (Exception ex)
            {
              
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(vm);
        }


        private string UploadFile(ProduceCreateViewModel vm)
        {
            string filename = null;
            if(vm.ImagePath!= null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Content/Image/");
                filename=Guid.NewGuid().ToString()+"_" + vm.ImagePath.FileName;
                string filePath= Path.Combine(uploadFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.ImagePath.CopyTo(fileStream);
                }
            }
            return filename;
        }

        [HttpGet]
        public IActionResult  Edit(int id)
        {
            var data=_context.Products.Include(x => x.Category).Where(x => x.ProductId ==id).SingleOrDefault();
            if (data == null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");

            }
            
        }
        [HttpPost]
        public IActionResult Edit(ProduceCreateViewModel vm) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _context.Products.Include(x => x.Category).Where(x => x.ProductId==vm.ProductId).SingleOrDefault();
                    string FileName = string.Empty;
                    if(vm.ImagePath!= null)
                    {
                        if(data.ImageUrl!=null)
                        {
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Content/Image", data.ImageUrl);
                            if(System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            } 
                        }
                        FileName=UploadFile(vm);
                    }
                    data.ProductName = vm.ProductName;
                    data.Description = vm.Description;
                    data.CategoryId = vm.CategoryId;
                    data.Price = vm.Price;
                    data.Size = vm.Size;

                    data.Condition = vm.Condition;
                    data.PostedOn = DateTime.Now;
                    if(vm.ImagePath!=null)
                    {
                        data.ImageUrl=FileName;
                    }
                    _context.Products.Update(data);
                    _context.SaveChanges();
                                

                }
                else
                {
                    return View(vm);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Index");
        }
    public IActionResult Delete(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            else
            {
                var data = _context.Products.Where(x => x.ProductId==id).SingleOrDefault();
                if(data!=null)
                {
                    string deleteFromFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Content/Image/");
                    string currentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFromFolder, data.ImageUrl);
                    if(currentImage!=null)
                    {
                        if (System.IO.File.Exists(currentImage))
                        {
                            System.IO.File.Delete(currentImage);
                        }
                    }
                    _context.Products.Remove(data);
                    _context.SaveChanges();
                }
            
            }
            return RedirectToAction("Index");
        }
        public  IActionResult Details(int id)
        {
            if(id==0)
            {
                return NotFound();
            }

            var data = _context.Products.Where(x => x.ProductId==id).SingleOrDefault();         
            return View(data);  

        }


    }
}
