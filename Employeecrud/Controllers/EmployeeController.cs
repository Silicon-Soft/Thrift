using Employeecrud.Data;
using Employeecrud.Models;
using Employeecrud.Models.Demo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employeecrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public EmployeeController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext=mvcDbContext;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var employees = await mvcDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        
        public  async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModelRequest)
        {
            var employees = new Employee()
            {
                Id= Guid.NewGuid(),
                Name= addEmployeeViewModelRequest.Name,
                Email= addEmployeeViewModelRequest.Email,
                Salary= addEmployeeViewModelRequest.Salary,
                Department= addEmployeeViewModelRequest.Department,
                DateOfBirth= addEmployeeViewModelRequest.DateOfBirth,

            };
            await mvcDbContext.Employees.AddAsync(employees);
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
            var employee=await mvcDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employee != null)
            {
                var UpdateViewModel = new UpdateViewModel()
                {
                    Id= employee.Id,
                    Name= employee.Name,
                    Email= employee.Email,
                    Salary= employee.Salary,
                    Department= employee.Department,
                    DateOfBirth= employee.DateOfBirth,


                };
                return await Task.Run(() => View("View", UpdateViewModel));



            }
          
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateViewModel model)
        {
            var employee = await mvcDbContext.Employees.FindAsync(model.Id);
            if(employee!= null)
            {
                employee.Name=model.Name;
                employee.Email=model.Email;
                employee.Salary=model.Salary;
                employee.Department=model.Department;
                employee.DateOfBirth=model.DateOfBirth;
                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }

}
