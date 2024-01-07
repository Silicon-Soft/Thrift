using CrudEmployee.Data;
using CrudEmployee.Services;
using Microsoft.EntityFrameworkCore;

namespace CrudEmployee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EmployeeDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString
            ("CrudConnectionString")));
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEmployeeService, EmployeeServices>();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}