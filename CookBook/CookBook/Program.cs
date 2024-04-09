using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

            using (var scope = app.Services.CreateScope())
                {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string email = "admin@admin.com";
                string id = "b2d13a3c-8547-4d6d-b7d0-a89322b762ra";
                string username = "Admin";
                string password = "admin123";
                var admin = await userManager.FindByIdAsync(id);

                if (admin == null)
                    {
                    var newAdmin = new IdentityUser()
                        {
                        Id = id,
                        UserName = username,
                        Email = email,
                        };
                    newAdmin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(newAdmin, password);

                    await userManager.CreateAsync(newAdmin);
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                    }
                else
                    {
                    await userManager.AddToRoleAsync(admin, "Admin");
                    }
                }

            app.Run();
            }
        }
    }