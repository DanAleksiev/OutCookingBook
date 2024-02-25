using CookBook.Data.Configuration;
using CookBook.Data.Models.Drinks;
using CookBook.Data.Models.Food;
using CookBook.Data.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Data
    {
    public class CookBookDbContext : IdentityDbContext
        {
        public CookBookDbContext(DbContextOptions<CookBookDbContext> options)
            : base(options)
            {
            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<IngredientFoodRecepie>(x =>
                x.HasKey(k =>
                    new { k.IngredientId, k.RecepieId }));

            modelBuilder.Entity<IngredientDrinkRecepie>(x =>
              x.HasKey(k =>
                  new { k.IngredientId, k.RecepieId }));

            modelBuilder
                .Entity<FoodRecepiesUsers>()
                .HasKey(x => new { x.FoodRecepieId, x.UserId });

            modelBuilder
                .Entity<FoodRecepiesUsers>()
                .HasOne(x => x.FoodRecepie)
                .WithMany(x => x.RecepiesUsers)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<FoodRecepiesUsers>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
               .Entity<FavouriteFoodRecepiesUsers>()
               .HasKey(x => new { x.FoodRecepieId, x.UserId });

            modelBuilder
                .Entity<FavouriteFoodRecepiesUsers>()
                .HasOne(x => x.FoodRecepie)
                .WithMany(x=>x.FavouriteRecepiesUsers)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<FavouriteFoodRecepiesUsers>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
               .Entity<DrinkRecepiesUsers>()
               .HasKey(x => new { x.DrinkRecepieId, x.UserId });

            modelBuilder
                .Entity<DrinkRecepiesUsers>()
                .HasOne(x => x.DrinkRecepie)
                .WithMany(x=>x.RecepiesUsers)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<DrinkRecepiesUsers>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<IdentityUser>().HasData(ConfigHelper.Users);
            modelBuilder.Entity<RecepieType>().HasData(ConfigHelper.RecepieTypes);
            modelBuilder.Entity<OvenType>().HasData(ConfigHelper.OveTypes);
            modelBuilder.Entity<Measurement>().HasData(ConfigHelper.Measurements);
            modelBuilder.Entity<TemperatureMeasurment>().HasData(ConfigHelper.TemperatureMeasurments);

            base.OnModelCreating(modelBuilder);
            }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FoodRecepiesUsers> FoodRecepiesUsers { get; set; }
        public DbSet<FavouriteFoodRecepiesUsers> FavouriteFoodRecepiesUsers { get; set; }
        public DbSet<FoodRecepie> FoodRecepies { get; set; }
        public DbSet<DrinkRecepiesUsers> DrinksRecepiesUsers { get; set; }
        public DbSet<DrinkRecepie> DrinkRecepies { get; set; }
        public DbSet<IngredientFoodRecepie> IngredientFoodRecepies { get; set; }
        public DbSet<IngredientDrinkRecepie> IngredientDrinkRecepies { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<OvenType> OvenTypes { get; set; }
        public DbSet<RecepieType> RecepieTypes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<TemperatureMeasurment> TemperaturesMeasurments { get; set; }
        }
    }
