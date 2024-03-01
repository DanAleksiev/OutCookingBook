using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using CookBook.Core.Models.Utilities;
using CookBook.Infrastructures.Data;
using CookBook.Core.Models.Recepies;
using CookBook.Infrastructures.Data.Models.Shared;
using CookBook.Core.Models.Ingredients;
using System.Text.Json;
using CookBook.Core;
using CookBook.Core.DTO;

namespace CookBook.Controllers
    {
    [Authorize]
    public class RecepieController : Controller
        {
        private List<Ingredient> ingredients;
        private List<Step> steps;
        private readonly CookBookDbContext context;
        public RecepieController(CookBookDbContext _context)
            {
            context = _context;
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
            }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private async Task<IEnumerable<UtilTypeModel>> GetMeasurmentType()
            {
            return await context
                .Measurements
                .Select(t => new UtilTypeModel()
                    {
                    Id = t.Id,
                    Name = t.Name,
                    })
                .ToListAsync();
            }
        private async Task<IEnumerable<UtilTypeModel>> GetOvenType()
            {
            return await context
                .OvenTypes
                .Select(t => new UtilTypeModel()
                    {
                    Id = t.Id,
                    Name = t.Name,
                    })
                .ToListAsync();
            }
        private async Task<IEnumerable<UtilTypeModel>> GetRecepieType()
            {
            return await context
                .RecepieTypes
                .Select(t => new UtilTypeModel()
                    {
                    Id = t.Id,
                    Name = t.Name,
                    })
                .ToListAsync();
            }
        [HttpGet]
        public IActionResult All()
            {
            //var allRecepies = context.Recepies.Select(x => new RecepieViewModel());
            return View();
            }

        [HttpPost]
        public IActionResult All(TempView model)
            {
            var name = model.Name;

            return View();
            }

        [HttpGet]
        public async Task<IActionResult> Add()
            {
            var model = new RecepieViewModel()
                {
                RecepieTypes = await GetRecepieType(),
                OvenTypes = await GetOvenType(),
                MeasurmentTypes = await GetMeasurmentType(),
                };

            return View(model);
            }

        [HttpPost]
        public IActionResult Add(RecepieViewModel model)
            {
            if (!ModelState.IsValid)
                {
                return View("Add", model);
                }

            List<Ingredient> ingredients = new List<Ingredient>();


            //var NewRecepie = new Recepie()
            //    {
            //    Name = model.Name,

            //    DatePosted = DateTime.Now,
            //    Image = model.Image,
            //    PrepTime = model.PrepTime,
            //    CookTime = model.CookTime,
            //    Portions = model.Portions,
            //    Origen = model.Origen,
            //    Preparation = model.Preparation,
            //    Temperature = model.Temperature,
            //    OwnerId = GetUserId(),
            //    };

            return RedirectToAction("All");
            }

        [HttpGet]
        public async Task<IActionResult> _AddIngredientPartial()
            {
            var model = new IngredientInputViewModel()
                {
                Measurements = await GetMeasurmentType(),
                };

            return View(model);
            }


        public IActionResult Delete()
            {
            return View();
            }

        public IActionResult EditYourRecepie()
            {
            return View();
            }

        public IActionResult EditSomeoneOtherRecepie()
            {
            return View();
            }


        [HttpPost]
        public JsonResult POSTIngredients(string allIngredient, string steps)
            {
            Console.WriteLine("serIng: " + allIngredient);
            Console.WriteLine("serIng" + steps);

            TempIngrediantModel[] ingredientsListDTO = allIngredient.DeserializeFromJson<TempIngrediantModel[]>();
            TempStepModel[] stepListDTO = allIngredient.DeserializeFromJson<TempStepModel[]>();

            foreach (var ing in ingredientsListDTO)
                {
                Ingredient newIng = new Ingredient() { 
                    Name = ing.Name,
                    Amount = ing.Amount,
                    MeasurementId = ing.MeasurementId
                    };
                }

            foreach (var step in stepListDTO)
                {
                Step newIng = new Step()
                    {
                    Position = step.Position,
                    Description = step.Description,
                    };
                }

            //Console.WriteLine("{desIng}: " + ingredientsListDTO);
            //Console.WriteLine();
            //Console.WriteLine("{desStep}: " + stepList);
            return new JsonResult(Ok());
            }

        }
    }
