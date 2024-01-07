using CrudEmployee.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEmployee.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
       : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
