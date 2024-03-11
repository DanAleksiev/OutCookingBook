using CookBook.Core;
using CookBook.Infrastructures.Data;
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


        public async Task<IActionResult> SeedFoodRecepies()
            {
            var recepies = await context.FoodRecepies
                .ToArrayAsync();
            var result = recepies.SerializeToJson();
            await Console.Out.WriteLineAsync();

            var exportDir = "";

            var path = "../../../Seed/FoodRecepies.json";
            using (StreamWriter sw = new StreamWriter(path))
                {

                sw.WriteLine(result);

                }
            return RedirectToAction("All", "Food");
            }

        public async Task<IActionResult> SeedDrinkRecepies()
            {
            var recepies = await context.DrinkRecepies
                .ToArrayAsync();
            var result = recepies.SerializeToJson();
            await Console.Out.WriteLineAsync();

            var exportDir = "";

            var path = "../../../Seed/DrinkRecepies.json";
            using (StreamWriter sw = new StreamWriter(path))
                {

                sw.WriteLine(result);

                }
            return RedirectToAction("All", "Drink");
            }
        }
    }
