using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Thrift1.Models;

namespace Thrift1.Data
{
    public class ThriftDbContext:IdentityDbContext
    {
        public ThriftDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
