using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using Thrift_Us.Data;

namespace Thrift_Us.Areas.Admin.Controllers
{

    public class AdminController : Controller
    {

        private readonly ThriftDbContext _context;

        public AdminController(ThriftDbContext context)
        {
            _context = context;

        }
       
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (claim != null)
                {

                    var users = _context.ApplicationUsers.ToList();
                    return View(users);
                }
            }


            return RedirectToAction("Login", "Account");
        }
    }
}
