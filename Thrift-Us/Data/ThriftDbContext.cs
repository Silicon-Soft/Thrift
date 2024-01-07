using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Thrift_Us.Models;

namespace Thrift_Us.Data
{
    public class ThriftDbContext: IdentityDbContext
    {
        public ThriftDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser>ApplicationUsers{ get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
