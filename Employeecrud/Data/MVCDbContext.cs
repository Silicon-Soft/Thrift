using Employeecrud.Models.Demo;
using Microsoft.EntityFrameworkCore;
namespace Employeecrud.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
