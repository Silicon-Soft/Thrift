using CrudEmployee.Services;
using CrudEmployee.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
     
        public IActionResult Index()
        {
            return View(_employeeService.EmployeeViewModels());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                _employeeService.Create(employeeViewModel);
                return RedirectToAction("Index", "Employee");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
         
        }
        public IActionResult Edit(int id)
        {
            return View(_employeeService.Read(id));
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult Edit(EmployeeViewModel employeeViewData)
        {
            _employeeService.Edit(employeeViewData);
            return RedirectToAction("Index", "Employee");
        }
        public IActionResult Read(int id)
        {
            return View(_employeeService.Read(id));
        }
        public IActionResult ConfirmDelete(int id)
        {
            return View(_employeeService.Read(id));
        }
        [HttpPost, ActionName("ConfirmDelete")]
        public IActionResult Delete(int id)
        {
            _employeeService.ConfirmDelete(id);
            return RedirectToAction("Index", "Employee");
        }

    }
}
