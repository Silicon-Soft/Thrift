using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Thrift_Us.Areas.Admin.Controllers
{

    public class AdminController : Controller
    {
        public IActionResult Dashboards()
        {
            return View();
        }
    }
}
