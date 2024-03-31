using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

namespace CookBook
    {
    public class Program
        {
        public static async Task Main(string[] args)
            {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddApplicationIdentity(builder.Configuration);

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            builder.Services.AddAplicationServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
                {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                }
            else
                {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
                app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            using (var scope = app.Services.CreateScope())
                {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Chef", "Member", "Barman" };

                foreach (var role in roles)
                    {
                    if (!await roleManager.RoleExistsAsync(role))
                        {
                        await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }
                }

            //using (var scope = app.Services.CreateScope())
            //    {
            //    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //    string email = "admin@admin.com";
            //    string password = "admin123";

            //    if (await userManager.FindByEmailAsync(email) == null)
            //        {
            //        var admin = new IdentityUser()
            //            {
            //            Id = "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
            //            UserName = "Admin",
            //            Email = email,
            //            //NormalizedUserName = "ADMIN@ADMIN.COM",
            //            };

            //        await userManager.CreateAsync(admin, password);
            //        await userManager.AddToRoleAsync(admin, "Admin");
            //        }
            //    else
            //        {
            //        var admin = await userManager.FindByEmailAsync(email);
            //        await userManager.AddToRoleAsync(admin, "Admin");
            //        }
            //    }

            app.Run();
            }
        }
    }