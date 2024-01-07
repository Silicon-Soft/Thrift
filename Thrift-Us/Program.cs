using Microsoft.EntityFrameworkCore;
using Thrift_Us.Data;
using Microsoft.AspNetCore.Identity;
using Thrift_Us.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Thrift_Us.Services;

namespace Thrift_Us
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ThriftDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("ThriftConnectionString")));

            builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ThriftDbContext>();
            _=builder.Services.AddScoped<IThriftService, ThriftService>();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            builder.Services.AddAutoMapper(typeof(MapperProfile));




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();;

            app.UseAuthorization();
            app.MapRazorPages();
            app.UseStaticFiles();

            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}