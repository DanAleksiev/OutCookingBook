using CookBook.Core;
using CookBook.Core.DTO;
using CookBook.Core.Utilities;
using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CookBook.Controllers
    {
    public class SeedController : Controller
        {
        //dont forget to delete 
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

            string[] testOwners = new string[]
                {
                    "566ffce9-543c-4218-93e1-dcc3e0d00fb5",
                    "49ec3dac-49bf-4d50-a7c1-c7f1fae6619d"
                    };

            bool[] isPrivate = new bool[]
                {
                    true,
                    false,
                    };

            var random = new Random();
            var template = new FoodRecepie()
                {
                Name = names[random.Next(0, names.Length - 1)],
                Descripton = description,
                DatePosted = DateTime.Parse(dates[random.Next(0, dates.Length - 1)]),
                Image = "NeedToFIgureImages",
                PrepTime = random.Next(0, 20),
                CookTime = random.Next(0, 120),
                Origen = countries[random.Next(0, countries.Length - 1)],
                OwnerId = testOwners[random.Next(0, testOwners.Length - 1)],
                Portions = random.Next(0, 6),
                RecepieTypeId = random.Next(0, 4),
                Temperature = random.Next(180, 400),
                TemperatureMeasurmentId = random.Next(0, 1),
                OvenTypeId = random.Next(0, 3),
                IsPrivate = isPrivate[random.Next(0, 1)],
                TumbsUp = 0,
                };

            List<Ingredient> addIngredients = new List<Ingredient>();
            List<FoodStep> addSteps = new List<FoodStep>();

            for (int i = 0; i < random.Next(2,6); i++)
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

                    Name = ingNames[random.Next(0,ingNames.Length-1)],
                    Amount = random.Next(0,400),
                    MeasurementId = random.Next(0,9),
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
            return RedirectToAction("All", "Food");
            }

        public async Task GenerateNewRandomDrinkRecepies()
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

            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

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

            string[] testOwners = new string[]
                {
                    "566ffce9-543c-4218-93e1-dcc3e0d00fb5",
                    "49ec3dac-49bf-4d50-a7c1-c7f1fae6619d"
                    };

            bool[] isPrivate = new bool[]
                {
                    true,
                    false,
                    };

            var random = new Random();
            var template = new DrinkRecepie()
                {
                Name = names[random.Next(0, names.Length - 1)],
                Descripton = description,
                DatePosted = DateTime.Parse(dates[random.Next(0, dates.Length - 1)]),
                Image = "NeedToFIgureImages",
                Origen = countries[random.Next(0, countries.Length - 1)],
                OwnerId = testOwners[random.Next(0, testOwners.Length - 1)],
                Cups = random.Next(0, 6),
                IsPrivate = isPrivate[random.Next(0, 1)],
                IsAlcoholic = isPrivate[random.Next(0, 1)],
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
                    MeasurementId = random.Next(0, 9),
                    };

                addIngredients.Add(newIng);
                }


            foreach (var step in addSteps)
                {
                var stepRecepie = new DrinkStepDrinkRecepie()
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
