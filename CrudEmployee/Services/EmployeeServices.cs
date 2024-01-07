using CrudEmployee.Data;
using CrudEmployee.Models;
using CrudEmployee.Services;
using CrudEmployee.ViewModel;
using Microsoft.EntityFrameworkCore;
public class EmployeeServices : IEmployeeService
{
        private readonly EmployeeDbContext _context;

        public EmployeeServices(EmployeeDbContext context)
        {
            _context = context;
        }
        public List<EmployeeViewModel> EmployeeViewModels()
        {
            List<Employee> employees = _context.Employees.AsNoTracking().ToList();
            List<EmployeeViewModel> EmployeeViewModels = new List<EmployeeViewModel>();

            foreach (var employee in employees)
            {
                EmployeeViewModels.Add(new EmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    Salary = employee.Salary
                });
            }

            return EmployeeViewModels;
        }
        public EmployeeViewModel Read(int id)
        {
            Employee employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return null;
            }

            EmployeeViewModel EmployeeViewModel = new EmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Phone = employee.Phone,
                Email = employee.Email,
                Salary = employee.Salary
            };

            return EmployeeViewModel;
        }
        public void Create(EmployeeViewModel EmployeeViewModel)
        {
            Employee employee = new Employee()
            {
                Id = EmployeeViewModel.Id,
                Name = EmployeeViewModel.Name,
                Phone = EmployeeViewModel.Phone,
                Email = EmployeeViewModel.Email,
                Salary = EmployeeViewModel.Salary
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
      
        public void Edit(EmployeeViewModel EmployeeViewModel)
        {
            Employee employee = new Employee()
            {
                Id = EmployeeViewModel.Id,
                Name = EmployeeViewModel.Name,
                Phone = EmployeeViewModel.Phone,
                Email = EmployeeViewModel.Email,
                Salary = EmployeeViewModel.Salary
            };
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
    public void ConfirmDelete(int id)
    {
        Employee employee = _context.Employees.Find(id)!;
        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }


}




 
