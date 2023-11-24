using BlogProjectOnion.Application.Extensions;
using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Infrastructure.Context;
using BlogProjectOnion.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Configuration;

namespace BlogProjectOnion.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddHttpClient();
			builder.Services.AddAuthorization();

			builder.Services.LoadDataLayerExtension(builder.Configuration);
			builder.Services.LoadServiceLayerExtension();
			builder.Services.AddSession();
			
			// Add services to the container.
			builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions()
            {
                PositionClass = ToastPositions.TopRight,
                TimeOut = 3000,
            })
              .AddRazorRuntimeCompilation();
            builder.Services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;

            })
            .AddRoleManager<RoleManager<AppRole>>()
            .AddErrorDescriber<IdentityErrorDescriber>()
            .AddEntityFrameworkStores<AppDbContext>()
           .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = new PathString("/Auth/Login");
                config.LogoutPath = new PathString("/Auth/Logout");
                config.Cookie = new CookieBuilder
                {
                    Name = "BlogProjectOnion",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.None //Always 

                };
                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromDays(7);
                config.AccessDeniedPath = new PathString("/Auth/AccessDenied");

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
			app.UseStatusCodePagesWithReExecute("/Auth/Error404/");
			app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();


            //app.MapControllerRoute(

            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "{area:exists}/{controller=Home1}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            app.Run();
        }
    }
}