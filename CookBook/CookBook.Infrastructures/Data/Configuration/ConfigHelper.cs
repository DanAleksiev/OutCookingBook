using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Identity;

namespace CookBook.Data.Configuration
{
    public static class ConfigHelper
        {
        public static Measurement[] Measurements = SeedMesurement();
        public static OvenType[] OveTypes = SeedOvenType();
        public static IdentityUser Users = SeedUser();
        public static RecepieType[] RecepieTypes = SeedRecepieTipe();
        public static TemperatureMeasurment[] TemperatureMeasurments = SeedTemperatureMeasurments();
        private static IdentityUser SeedUser()
            {
            var testUser = new IdentityUser()
                {
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM"
                };

            testUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(testUser, "softuni");
            return testUser;
            }

        private static TemperatureMeasurment[] SeedTemperatureMeasurments()
            {
            return new TemperatureMeasurment[]{
                    new TemperatureMeasurment
                        {
                        Id = 1,
                        Name = "ºC",
                        },
                    new TemperatureMeasurment
                        {
                        Id = 2,
                        Name = "ºF"
                        }
                    };
            }

        public static Measurement[] SeedMesurement()
            {
            return new Measurement[]{
                new Measurement
                    {
                    Id = 1,
                    Name = "Gram"
                    },
                new Measurement
                    {
                    Id = 2,
                    Name = "Ounce"
                    },
                new Measurement
                    {
                    Id = 3,
                    Name = "Table spoon",
                    },
                new Measurement
                    {
                    Id = 4,
                    Name = "Cups",
                    },
                new Measurement
                    {
                    Id = 5,
                    Name = "Milliliter"
                    },
                new Measurement
                    {
                    Id = 6,
                    Name = "Liter"
                    },
                new Measurement
                    {
                    Id = 7,
                    Name = "Pinch"
                    },
                new Measurement
                    {
                    Id = 8,
                    Name = "Each"
                    }
                };
            }

        public static OvenType[] SeedOvenType()
            {
            return new OvenType[]
                {
                 new OvenType
                    {
                    Id = 1,
                    Name = "Conventional"
                    },

                new OvenType
                    {
                    Id = 2,
                    Name = "Fan",
                    },
                new OvenType
                    {
                    Id = 3,
                    Name = "Gas",
                    },
                new OvenType
                    {
                    Id = 4,
                    Name = "No oven needed"
                    }
                };
            }
        public static RecepieType[] SeedRecepieTipe()
            {
            return new RecepieType[]
            {
                new RecepieType
                    {
                    Id = 1,
                    Description = "A salad is a dish consisting of mixed ingredients, frequently vegetables. They are typically served chilled or at room temperature, though some can be served warm. Condiments and salad dressings, which exist in a variety of flavors, are often used to enhance a salad.",
                    Name = "Salad",
                    },
                new RecepieType
                    {
                    Id = 2,
                    Description = "Soup is a primarily liquid food, generally served warm or hot (but may be cool or cold), that is made by combining ingredients of meat or vegetables with stock, milk, or water. Hot soups are additionally characterized by boiling solid ingredients in liquids in a pot until the flavors are extracted, forming a broth.",
                    Name = "Soup",
                    },
                new RecepieType
                    {
                    Id = 3,
                    Description = "pastry, stiff dough made from flour, salt, a relatively high proportion of fat, and a small proportion of liquid. It may also contain sugar or flavourings. Most pastry is leavened only by the action of steam, but Danish pastry is raised with yeast.",
                    Name = "Pastry"
                    },
                new RecepieType
                    {
                    Id = 4,
                    Description = "A stew is a combination of solid food ingredients that have been cooked in liquid and served in the resultant gravy. Ingredients can include any combination of vegetables and may include meat, especially tougher meats suitable for slow-cooking, such as beef, pork, venison, rabbit, lamb, poultry, sausages, and seafood.",
                    Name = "Stew"
                    },
                new RecepieType
                    {
                    Id = 20,
                    Description = "",
                    Name = "Other"
                    }
                };
            }
        }
    }

