using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Thrift_Us.Models;
using Thrift_Us.ViewModel;
using Thrift_Us.ViewModels;

namespace Thrift_Us.Data
{
    public class ThriftDbContext : IdentityDbContext<IdentityUser>
    {
        public ThriftDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Rental>Rentals { get; set; }
        public DbSet<RentalCart> RentalCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ApplicationUser)
                .WithMany()
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rental>()
      .Property(r => r.TotalPrice)
      .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<RentalViewModel>()
                .Property(r => r.RentalPrice)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>()
       .Property(p => p.RentalPrice)
       .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderDetails>()
        .Property(o => o.Price)
        .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<RentalCart>()
                .Property(r => r.TotalPrice)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<OrderDetails>()
       .Property(o => o.RentalPrice)
       .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<OrderHeader>()
           .HasOne(o => o.Rental)
           .WithMany()
           .HasForeignKey(o => o.RentalId)
           .OnDelete(DeleteBehavior.Restrict);
        }



    }

}
