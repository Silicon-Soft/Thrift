using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Thrift_Us.Models;
using Thrift_Us.Services.Interface;

namespace Thrift_Us.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService=productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetAllProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}