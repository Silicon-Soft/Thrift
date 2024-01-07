using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Thrift.Models;

namespace Thrift.Data
{
    public class ThriftDbContext: IdentityDbContext
    {
       

        public ThriftDbContext(DbContextOptions options) : base(options)
            {

            }
      
            
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles{ get; set; }
        //public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Shipment> Shipments { get; set; }
      
        //public DbSet<BillingAddress> BillingAddresss { get; set; }


    }








}
