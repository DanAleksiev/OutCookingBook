using CookBook.Data.Configuration;
using CookBook.Data.Models;
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
            modelBuilder.Entity<IngredientRecepie>(x =>
                x.HasKey(k =>
                    new { k.IngredientId, k.RecepieId }));

            modelBuilder
                .Entity<RecepiesUsers>()
                .HasKey(x => new { x.RecepieId, x.UserId });

            modelBuilder
                .Entity<RecepiesUsers>()
                .HasOne(x => x.Recepie)
                .WithMany()
                .HasForeignKey(e => e.RecepieId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<RecepiesUsers>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<IdentityUser>().HasData(ConfigHelper.Users);
            modelBuilder.Entity<RecepieType>().HasData(ConfigHelper.RecepieTypes);
            modelBuilder.Entity<OvenType>().HasData(ConfigHelper.OveTypes);
            modelBuilder.Entity<Measurement>().HasData(ConfigHelper.Measurements);
            modelBuilder.Entity<TemperatureMeasurment>().HasData(ConfigHelper.TemperatureMeasurments);

            base.OnModelCreating(modelBuilder);
            }

        public DbSet<RecepiesUsers> RecepiesUsers { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recepie> Recepies { get; set; }
        public DbSet<IngredientRecepie> IngredientRecepies { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<OvenType> OvenTypes { get; set; }
        public DbSet<RecepieType> RecepieTypes { get; set; }
        public DbSet<TemperatureMeasurment> TemperaturesMeasurments { get; set; }
        }
    }
