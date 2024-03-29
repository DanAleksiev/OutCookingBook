using CookBook.Core;
using CookBook.Core.Utilities;
using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CookBook.Controllers
    {
    [Authorize]
    public class SeedController : Controller
        {
        //dont forget to delete 
        private static string[] testOwners = new string[]
                {
                    "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                    "598014d6-5a1a-4b10-8246-543b8ecbc445"
                    };

        private readonly CookBookDbContext context;
        public SeedController(CookBookDbContext _context)
            {
            context = _context;
            }


        public async Task<IActionResult> FoodRecepiesToJSON()
            {
            var recepies = await context.FoodRecepies
                .ToArrayAsync();
            var result = recepies.SerializeToJson();
            await Console.Out.WriteLineAsync();


            var path = "../../../Seed/FoodRecepies.json";
            using (StreamWriter sw = new StreamWriter(path))
                {

                sw.WriteLine(result);

                }
            return RedirectToAction("All", "Food");
            }


        public async Task<IActionResult> FoodRecepiesFromJSON()
            {
            await GenerateNewRandomFoodRecepies();

            return RedirectToAction("All", "Food");
            }

        public async Task GenerateNewRandomFoodRecepies()
            {
            string[] names = new string[]{
                "Placeholder Soup",
                "Placeholder Dish",
                "Placeholder Pasta",
                "Placeholder Meat",
                "Placeholder Veggie",
                "Placeholder Salad",
                "Placeholder Sause",
                };

            string description = "Lorem ipsum dolor sit amet.";

            string[] dates = new string[]{
                    "11/03/2024",
                    "01/05/2024",
                    "11/12/2022",
                    "01/01/2021",
                    "02/02/1996",
                    };

            string[] countries = new string[]{
                    "Bulgaria",
                    "Albania",
                    "England",
                    "USA",
                    "China",
                    "Japan",
                    "Germany",
                    "Italy",
                    "France",
                    "Mexico",
                    "India",
                    "Australia",
                    };

            string[] foodImages = new string[]
                {
                    "https://www.southernliving.com/thmb/rWglUDMr6jxNu0pQyNYfgkiJI7E=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Lemon-Chicken-Thighs_TK517C_16x9-196_preview_scale_100_ppi_150_quality_100-5770c66a5145418894bd519c70faf0d6.jpg",
                    "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chorizo-mozarella-gnocchi-bake-cropped-9ab73a3.jpg?quality=90&resize=556,505",
                    "https://images.immediate.co.uk/production/volatile/sites/30/2013/05/Puttanesca-fd5810c.jpg",
                    "https://www.kayak.co.uk/news/wp-content/uploads/sites/5/2022/01/feature-image.jpg",
                    "https://www.seriouseats.com/thmb/DvSDZoMw8WSOQFAMgf3L2wlfY9Y=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/053123_TomatoSoup-MPPSoupsAndStews-Morgan-Hunt-Glaze-f59a081d7efb4625a75a1a907a6b1cbf.jpg",
                    "https://images.immediate.co.uk/production/volatile/sites/30/2017/11/Vegetable-soup-recipes-1eb6583.jpg?resize=768,574",
                    "https://images.immediate.co.uk/production/volatile/sites/30/2023/08/grilled-fish-colllection-60b560c.jpg?quality=90&resize=556,505",
                    };



            var random = new Random();
            var template = new FoodRecepie()
                {
                Name = names[random.Next(0, names.Length)],
                Descripton = description,
                DatePosted = DateTime.Parse(dates[random.Next(0, dates.Length)]),
                Image = foodImages[random.Next(0, foodImages.Length)],
                PrepTime = random.Next(1, 20),
                CookTime = random.Next(1, 120),
                Origen = countries[random.Next(0, countries.Length)],
                OwnerId = testOwners[random.Next(0, testOwners.Length)],
                Portions = random.Next(1, 6),
                RecepieTypeId = random.Next(1, 5),
                Temperature = random.Next(180, 400),
                TemperatureMeasurmentId = random.Next(1, 2),
                OvenTypeId = random.Next(1, 4),
                IsPrivate = false,
                TumbsUp = 0,
                };

            List<Ingredient> addIngredients = new List<Ingredient>();
            List<FoodStep> addSteps = new List<FoodStep>();

            for (int i = 0; i < random.Next(2, 6); i++)
                {
                FoodStep newStep = new FoodStep()
                    {
                    Position = i,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    };

                addSteps.Add(newStep);
                }


            string[] ingNames = new string[]
                {
                    "Placeholder Radish",
                    "Placeholder been",
                    "Placeholder Cucumber",
                    "Placeholder Peas",
                    "Placeholder Beef",
                    "Placeholder Vinegart",
                    "Placeholder oil",
                    "Placeholder Tomato",
                    "Placeholder pork",
                    "Placeholder Fish",
                    "Placeholder Garlic",
                    "Placeholder Mince",
                    "Placeholder Spaghetti",
                    "Placeholder Basil",
                    "Placeholder Peppers",
                    "Placeholder Onion",
                };

            for (int i = 0; i < random.Next(2, 6); i++)
                {
                Ingredient newIng = new Ingredient()
                    {

                    Name = ingNames[random.Next(0, ingNames.Length)],
                    Amount = random.Next(0, 400),
                    MeasurementId = random.Next(1, 9),
                    };

                addIngredients.Add(newIng);
                }


            foreach (var step in addSteps)
                {
                var stepRecepie = new FoodStepsFoodRecepies()
                    {
                    FoodRecepie = template,
                    FoodStep = step,
                    };

                await context.FoodStep.AddAsync(step);
                await context.FoodStepsFoodRecepies.AddAsync(stepRecepie);
                }

            foreach (var ing in addIngredients)
                {

                var ingFoodRec = new IngredientFoodRecepie
                    {
                    Ingredient = ing,
                    Recepie = template
                    };
                await context.Ingredients.AddAsync(ing);
                await context.IngredientFoodRecepies.AddAsync(ingFoodRec);
                }

            await context.FoodRecepies.AddAsync(template);


            try
                {
                await context.SaveChangesAsync();
                }
            catch (Exception ex)
                {
                await Console.Out.WriteLineAsync(ex.Message);
                if (ex.InnerException != null)
                    {
                    await Console.Out.WriteLineAsync(ex.GetCompleteMessage());
                    }
                }


            await context.SaveChangesAsync();

            }


        public async Task<IActionResult> DrinkRecepiesToJSON()
            {
            var recepies = await context.DrinkRecepies
                .ToArrayAsync();
            var result = recepies.SerializeToJson();
            await Console.Out.WriteLineAsync();

            var path = "../../../Seed/DrinkRecepies.json";
            using (StreamWriter sw = new StreamWriter(path))
                {

                sw.WriteLine(result);

                }
            return RedirectToAction("All", "Drink");
            }

        public async Task<IActionResult> DrinkRecepiesFromJSON()
            {
            await GenerateNewRandomDrinkRecepies();
            return RedirectToAction("All", "Drink");
            }

        public async Task GenerateNewRandomDrinkRecepies()
            {
            string[] names = new string[]{
                "Placeholder juice",
                "Placeholder Palms",
                "Placeholder Stroberry Blast",
                "Placeholder Sunshine",
                "Placeholder Blue lagoon",
                "Placeholder Paradicese",
                "Placeholder Rasberry recharge",
                };

            string description = "Lorem ipsum dolor sit amet";

            string[] dates = new string[]{
                    "11/03/2024",
                    "01/05/2024",
                    "11/12/2022",
                    "01/01/2021",
                    "02/02/1996",
                    };

            string[] countries = new string[]{
                    "Bulgaria",
                    "Albania",
                    "England",
                    "USA",
                    "China",
                    "Japan",
                    "Germany",
                    "Italy",
                    "France",
                    "Mexico",
                    "India",
                    "Australia",
                    };

            string[] drinkImages = new string[]
                {
                    "https://hips.hearstapps.com/hmg-prod/images/ice-tea-royalty-free-image-1621872849.jpg?resize=980:*",
                    "https://www.allrecipes.com/thmb/PSguDhMOlYcrYYQMBhQR1_EL7ck=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Long-Drink-4x3-1-89407cb356934c29bb09a1defc6a5b14.jpg",
                    "https://www.southernliving.com/thmb/YJTY4hKNKdaCZ4Hd9Y4_aHD8Zrw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Southern-Living-Paloma-3X2-1791-ab70507c3266414f81eb2dbcff31c413.jpg",
                    "https://hips.hearstapps.com/hmg-prod/images/sex-on-the-beach-vertical-6442f7c22a415.jpg",
                    "https://hips.hearstapps.com/hmg-prod/images/aperol-spritz-index-64763b53b0070.jpg",
                    "https://www.peelwithzeal.com/wp-content/uploads/2022/05/Red-White-and-Blue-Cocktail.jpg",
                    "https://images.immediate.co.uk/production/volatile/sites/30/2021/11/diabolo-mockail-440-x400-c795884.jpg?quality=90&resize=556,505",
                    };

            bool[] isAlcoholic = new bool[]
                {
                    true,
                    false,
                    };

            var random = new Random();
            var template = new DrinkRecepie()
                {
                Name = names[random.Next(0, names.Length)],
                Descripton = description,
                DatePosted = DateTime.Parse(dates[random.Next(0, dates.Length)]),
                Image = drinkImages[random.Next(0, drinkImages.Length)],
                Origen = countries[random.Next(0, countries.Length)],
                OwnerId = testOwners[random.Next(0, testOwners.Length)],
                Cups = random.Next(0, 6),
                IsPrivate = false,
                IsAlcoholic = isAlcoholic[random.Next(0, 1)],
                TumbsUp = 0,
                };

            List<Ingredient> addIngredients = new List<Ingredient>();
            List<DrinkStep> addSteps = new List<DrinkStep>();

            for (int i = 0; i < random.Next(2, 6); i++)
                {
                DrinkStep newStep = new DrinkStep()
                    {
                    Position = i,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    };

                addSteps.Add(newStep);
                }

            string[] ingNames = new string[]
                {
                    "Placeholder Radish",
                    "Placeholder been",
                    "Placeholder Cucumber",
                    "Placeholder Peas",
                    "Placeholder Beef",
                    "Placeholder Vinegart",
                    "Placeholder oil",
                    "Placeholder Tomato",
                    "Placeholder pork",
                    "Placeholder Fish",
                    "Placeholder Garlic",
                    "Placeholder Mince",
                    "Placeholder Spaghetti",
                    "Placeholder Basil",
                    "Placeholder Peppers",
                    "Placeholder Onion",
                };

            for (int i = 0; i < random.Next(2, 6); i++)
                {
                Ingredient newIng = new Ingredient()
                    {

                    Name = ingNames[random.Next(0, ingNames.Length - 1)],
                    Amount = random.Next(0, 400),
                    MeasurementId = random.Next(1, 9),
                    };

                addIngredients.Add(newIng);
                }


            foreach (var step in addSteps)
                {
                var stepRecepie = new DrinkStepsDrinkRecepies()
                    {
                    DrinkRecepie = template,
                    DrinkStep = step,
                    };

                await context.DrinkStep.AddAsync(step);
                await context.DrinkStepsDrinkRecepies.AddAsync(stepRecepie);
                }

            foreach (var ing in addIngredients)
                {

                var ingFoodRec = new IngredientDrinkRecepie
                    {
                    Ingredient = ing,
                    Recepie = template
                    };
                await context.Ingredients.AddAsync(ing);
                await context.IngredientDrinkRecepies.AddAsync(ingFoodRec);
                }

            await context.DrinkRecepies.AddAsync(template);


            try
                {
                await context.SaveChangesAsync();
                }
            catch (Exception ex)
                {
                await Console.Out.WriteLineAsync(ex.Message);
                if (ex.InnerException != null)
                    {
                    await Console.Out.WriteLineAsync(ex.GetCompleteMessage());
                    }
                }


            await context.SaveChangesAsync();

            }

        }
    }
