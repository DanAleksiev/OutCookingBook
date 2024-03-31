using CookBook.Areas.Admin.Contracts;
using CookBook.Areas.Admin.Services;
using CookBook.Core.Contracts;
using CookBook.Core.Services;
using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
    {
    public static class ServiceCollectionExtension
        {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
            {
            services.AddScoped<IFoodRecepieService, FoodRecepieService>();
            services.AddScoped<IDrinkRecepieService, DrinkRecepieService>();
            services.AddScoped<IAdminService, AdminService>();

            return services;
            }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
            {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<CookBookDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
            }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
            {
            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CookBookDbContext>();

            return services;
            }

        }
    }
