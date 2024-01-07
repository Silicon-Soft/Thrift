using Microsoft.EntityFrameworkCore;
using Thrift1.Data;
using Microsoft.AspNetCore.Identity;
/*using Thrift1.Service;*/

namespace Thrift1
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

                        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ThriftDbContext>();
        /*    builder.Services.AddControllersWithViews();
            _=builder.Services.AddScoped<IThriftServices, ThriftServices>();*/
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
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}