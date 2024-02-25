﻿// <auto-generated />
using System;
using CookBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookBook.Migrations
{
    [DbContext(typeof(CookBookDbContext))]
    partial class CookBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CookBook.Data.Models.Drinks.DrinkRecepie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cups")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PrepTime")
                        .HasColumnType("int");

                    b.Property<string>("Preparation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TumbsUp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("DrinkRecepies");
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.FavouriteFoodRecepiesUsers", b =>
                {
                    b.Property<int>("FoodRecepieId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FoodRecepieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavouriteFoodRecepiesUsers");
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.FoodRecepie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CookTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastTimeYouHadIt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OvenTypeId")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Portions")
                        .HasColumnType("int");

                    b.Property<int>("PrepTime")
                        .HasColumnType("int");

                    b.Property<string>("Preparation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecepieTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.Property<int>("TemperatureMeasurmentId")
                        .HasColumnType("int");

                    b.Property<int>("TumbsUp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OvenTypeId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RecepieTypeId");

                    b.HasIndex("TemperatureMeasurmentId");

                    b.ToTable("FoodRecepies");
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.FoodRecepiesUsers", b =>
                {
                    b.Property<int>("FoodRecepieId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FoodRecepieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FoodRecepiesUsers");
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.OvenType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OvenTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Conventional"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fan"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gas"
                        },
                        new
                        {
                            Id = 4,
                            Name = "No oven needed"
                        });
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.RecepieType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecepieTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A salad is a dish consisting of mixed ingredients, frequently vegetables. They are typically served chilled or at room temperature, though some can be served warm. Condiments and salad dressings, which exist in a variety of flavors, are often used to enhance a salad.",
                            Name = "Salad"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Soup is a primarily liquid food, generally served warm or hot (but may be cool or cold), that is made by combining ingredients of meat or vegetables with stock, milk, or water. Hot soups are additionally characterized by boiling solid ingredients in liquids in a pot until the flavors are extracted, forming a broth.",
                            Name = "Soup"
                        },
                        new
                        {
                            Id = 3,
                            Description = "pastry, stiff dough made from flour, salt, a relatively high proportion of fat, and a small proportion of liquid. It may also contain sugar or flavourings. Most pastry is leavened only by the action of steam, but Danish pastry is raised with yeast.",
                            Name = "Pastry"
                        },
                        new
                        {
                            Id = 4,
                            Description = "A stew is a combination of solid food ingredients that have been cooked in liquid and served in the resultant gravy. Ingredients can include any combination of vegetables and may include meat, especially tougher meats suitable for slow-cooking, such as beef, pork, venison, rabbit, lamb, poultry, sausages, and seafood.",
                            Name = "Stew"
                        },
                        new
                        {
                            Id = 20,
                            Description = "",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.TemperatureMeasurment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TemperaturesMeasurments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ºC"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ºF"
                        });
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.DrinkRecepiesUsers", b =>
                {
                    b.Property<int>("DrinkRecepieId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DrinkRecepieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DrinksRecepiesUsers");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("MeasurementId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.IngredientDrinkRecepie", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("RecepieId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId", "RecepieId");

                    b.HasIndex("RecepieId");

                    b.ToTable("IngredientDrinkRecepies");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.IngredientFoodRecepie", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("RecepieId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId", "RecepieId");

                    b.HasIndex("RecepieId");

                    b.ToTable("IngredientFoodRecepies");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Measurements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gram"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ounce"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Table spoon"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cups"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Milliliter"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Liter"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Pinch"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Each"
                        });
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrinkRecepieId")
                        .HasColumnType("int");

                    b.Property<int?>("FoodRecepieId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrinkRecepieId");

                    b.HasIndex("FoodRecepieId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "fe41dc26-4b4a-4b13-b641-bfeee2ab3f70",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bb38aa05-50ba-403e-bb4d-7643cefd2ea2",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "TEST@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJnqPQ3HrZch4vcvZ6CpTl242N/fo/iTXWJYbzW2mPub8mcn9oicI4/FGsixXATFdg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d232b4f0-a3bd-43e9-9e8d-813988c12a57",
                            TwoFactorEnabled = false,
                            UserName = "test@test.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CookBook.Data.Models.Drinks.DrinkRecepie", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.FavouriteFoodRecepiesUsers", b =>
                {
                    b.HasOne("CookBook.Data.Models.Food.FoodRecepie", "FoodRecepie")
                        .WithMany("FavouriteRecepiesUsers")
                        .HasForeignKey("FoodRecepieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FoodRecepie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.FoodRecepie", b =>
                {
                    b.HasOne("CookBook.Data.Models.Food.OvenType", "OvenType")
                        .WithMany()
                        .HasForeignKey("OvenTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookBook.Data.Models.Food.RecepieType", "RecepieType")
                        .WithMany()
                        .HasForeignKey("RecepieTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookBook.Data.Models.Food.TemperatureMeasurment", "TemperatureMeasurment")
                        .WithMany()
                        .HasForeignKey("TemperatureMeasurmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OvenType");

                    b.Navigation("Owner");

                    b.Navigation("RecepieType");

                    b.Navigation("TemperatureMeasurment");
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.FoodRecepiesUsers", b =>
                {
                    b.HasOne("CookBook.Data.Models.Food.FoodRecepie", "FoodRecepie")
                        .WithMany("RecepiesUsers")
                        .HasForeignKey("FoodRecepieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FoodRecepie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.DrinkRecepiesUsers", b =>
                {
                    b.HasOne("CookBook.Data.Models.Drinks.DrinkRecepie", "DrinkRecepie")
                        .WithMany("RecepiesUsers")
                        .HasForeignKey("DrinkRecepieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DrinkRecepie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.Ingredient", b =>
                {
                    b.HasOne("CookBook.Data.Models.Shared.Measurement", "Measurement")
                        .WithMany()
                        .HasForeignKey("MeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.IngredientDrinkRecepie", b =>
                {
                    b.HasOne("CookBook.Data.Models.Shared.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookBook.Data.Models.Drinks.DrinkRecepie", "Recepie")
                        .WithMany("IngredientsRecepies")
                        .HasForeignKey("RecepieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recepie");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.IngredientFoodRecepie", b =>
                {
                    b.HasOne("CookBook.Data.Models.Shared.Ingredient", "Ingredient")
                        .WithMany("IngredientsRecepies")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookBook.Data.Models.Food.FoodRecepie", "Recepie")
                        .WithMany("IngredientsRecepies")
                        .HasForeignKey("RecepieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recepie");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.Step", b =>
                {
                    b.HasOne("CookBook.Data.Models.Drinks.DrinkRecepie", null)
                        .WithMany("Steps")
                        .HasForeignKey("DrinkRecepieId");

                    b.HasOne("CookBook.Data.Models.Food.FoodRecepie", null)
                        .WithMany("Steps")
                        .HasForeignKey("FoodRecepieId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CookBook.Data.Models.Drinks.DrinkRecepie", b =>
                {
                    b.Navigation("IngredientsRecepies");

                    b.Navigation("RecepiesUsers");

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("CookBook.Data.Models.Food.FoodRecepie", b =>
                {
                    b.Navigation("FavouriteRecepiesUsers");

                    b.Navigation("IngredientsRecepies");

                    b.Navigation("RecepiesUsers");

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("CookBook.Data.Models.Shared.Ingredient", b =>
                {
                    b.Navigation("IngredientsRecepies");
                });
#pragma warning restore 612, 618
        }
    }
}
