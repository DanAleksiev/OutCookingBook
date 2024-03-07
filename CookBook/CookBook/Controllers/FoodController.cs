using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using CookBook.Core.Models.Utilities;
using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Models.Shared;
using CookBook.Core;
using CookBook.Core.DTO;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Core.Utilities;
using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;

namespace CookBook.Controllers
{
    [Authorize]
    public class FoodController : Controller
        {
        private static List<Ingredient> addIngredients = new List<Ingredient>();
        private static List<FoodStep> addSteps { get; set; } = new List<FoodStep>();

        private readonly CookBookDbContext context;
        public FoodController(CookBookDbContext _context)
            {
            context = _context;
            }


        /// <summary>
        /// Suppoting methods to make my life easier
        /// </summary>
        /// <returns></returns>
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

        private async Task<IEnumerable<UtilTypeModel>> GetTemperatureType()
            {
            return await context
                .TemperaturesMeasurments
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


        /// <summary>
        /// Actions from now on
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult All()
            {
            ViewBag.Title = "All food recepies";

            var allRecepies = context
                .FoodRecepies
                .Where(x => !x.IsPrivate)
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    DatePosted = x.DatePosted.ToString("dd/MM/yyyy"),
                    Image = x.Image,
                    TumbsUp = x.TumbsUp,
                    Description = x.Descripton,
                    Owner = x.Owner.UserName
                    })
                .AsNoTracking()
                .ToList();

            return View(allRecepies);
            }

        [HttpGet]
        public IActionResult Private()
            {
            ViewBag.Title = "Private food recepies";

            var allRecepies = context
                .FoodRecepies
                .Where(x => x.OwnerId == GetUserId())
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    DatePosted = x.DatePosted.ToString("dd/MM/yyyy"),
                    Image = x.Image,
                    TumbsUp = x.TumbsUp,
                    Description = x.Descripton,
                    Owner = x.Owner.UserName
                    })
                .AsNoTracking()
                .ToList();

            return View("All", allRecepies);
            }


        [HttpGet]
        public async Task<IActionResult> Add()
            {
            var model = new FoodViewModel()
                {
                RecepieTypes = await GetRecepieType(),
                OvenTypes = await GetOvenType(),
                MeasurmentTypes = await GetMeasurmentType(),
                TemperatureTypes = await GetTemperatureType(),
                };

            return View(model);
            }

        [HttpPost]
        public async Task<IActionResult> Add(FoodViewModel model)
            {
            if (!ModelState.IsValid)
                {
                return View("Add", model);
                }

            var newRecepie = new FoodRecepie()
                {
                Name = model.Name,
                Descripton = model.Description,
                DatePosted = DateTime.Now,
                Image = model.Image,
                PrepTime = model.PrepTime,
                CookTime = model.CookTime,
                Portions = model.Portions,
                OvenTypeId = model.OvenTypeId,
                RecepieTypeId = model.RecepieTypeId,
                Origen = model.Origen,
                Temperature = model.Temperature,
                TemperatureMeasurmentId = model.TemperatureTypeId,
                OwnerId = GetUserId(),
                TumbsUp = 0,
                IsPrivate = model.IsPrivate,
                };


            foreach (var step in addSteps)
                {
                var stepRecepie = new FoodStepsFoodRecepies()
                    {
                    FoodRecepie = newRecepie,
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
                    Recepie = newRecepie
                    };
                await context.Ingredients.AddAsync(ing);
                await context.IngredientFoodRecepies.AddAsync(ingFoodRec);
                }

            await context.FoodRecepies.AddAsync(newRecepie);


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

            addIngredients.Clear();
            addSteps.Clear();
            return RedirectToAction("All");
            }

        public IActionResult Delete()
            {
            return View();
            }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
            {
            var recepie = await context.FoodRecepies.FindAsync(id);

            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }

            var model = new EditFoodForm()
                {
                Id = recepie.Id,
                Name = recepie.Name,
                Description = recepie.Descripton,
                RecepieTypeId = recepie.Id,
                RecepieTypes = await GetRecepieType(),
                Image = recepie.Image,
                PrepTime = recepie.PrepTime,
                CookTime = recepie.CookTime,
                Temperature = recepie.Temperature,
                TemperatureTypeId = recepie.TemperatureMeasurmentId,
                TemperatureTypes = await GetTemperatureType(),
                OvenTypeId = recepie.OvenTypeId,
                OvenTypes = await GetOvenType(),
                MeasurmentId = recepie.TemperatureMeasurmentId,
                MeasurmentTypes = await GetMeasurmentType(),
                IsPrivate = recepie.IsPrivate,
                Origen = recepie.Origen,
                Portions = recepie.Portions,
                };

            return View(model);
            }

        [HttpPost]
        public async Task<IActionResult> Edit(EditFoodForm model)
            {
            if (!ModelState.IsValid)
                {
                return View("Edit", model);
                }

            var recepie = await context.FoodRecepies.FindAsync(model.Id);

            if (recepie == null)
                {
                return BadRequest(ModelState);
                }

            if (recepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }

            recepie.Name = model.Name;
            recepie.Descripton = model.Description;
            recepie.Image = model.Image;
            recepie.PrepTime = model.PrepTime;
            recepie.CookTime = model.CookTime;
            recepie.Portions = model.Portions;
            recepie.OvenTypeId = model.OvenTypeId;
            recepie.RecepieTypeId = model.RecepieTypeId;
            recepie.IsPrivate = model.IsPrivate;
            recepie.Origen = model.Origen;
            recepie.Temperature = model.Temperature;
            recepie.TemperatureMeasurmentId = model.TemperatureTypeId;


            await context.SaveChangesAsync();


            return RedirectToAction("All");
            }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
            {
            var recepie = await context
                .FoodRecepies
                .Where(x => x.Id == id)
                .Select(x => new DetailedFoodViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Descripton,
                    RecepieType = x.RecepieType.Name,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    PrepTime = x.PrepTime,
                    CookTime = x.CookTime,
                    Temperature = x.Temperature,
                    TemperatureType = x.TemperatureMeasurment.Name,
                    
                    OvenType = x.OvenType.Name,
                    Origen = x.Origen,
                    TumbsUp = x.TumbsUp,
                    Portions = x.Portions,
                    Owner = x.Owner.UserName,
                    })
                .FirstOrDefaultAsync();

            if (recepie == null)
                {
                return BadRequest();
                }

            var ing = await context
                .IngredientFoodRecepies
                .Include(x=>x.Ingredient)
                .Include(x=>x.Ingredient.Measurement)
                .Where(x => x.RecepieId == recepie.Id)
                .Select(x => new Ingredient()
                    {
                    Id = x.IngredientId,
                    Amount = x.Ingredient.Amount,
                    Calories = x.Ingredient.Calories,
                    Name = x.Ingredient.Name,
                    Measurement = x.Ingredient.Measurement,
                    })
                .ToListAsync();

            var steps = await context
                .FoodStepsFoodRecepies
                .Where(x => x.FoodRecepieId == recepie.Id)
                .Select(x => new FoodStep()
                    {
                    Id = x.FoodStep.Id,
                    Description = x.FoodStep.Description,
                    Position = x.FoodStep.Position,
                    })
                .OrderBy(x => x.Position)
                .ToListAsync();

            recepie.Ingredients = ing;
            recepie.Steps = steps;
            return View(recepie);
            }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
            {
            var recepie = await context
                .FoodRecepies
                .Where(x => x.Id == id)
                .Select(x => new DetailedFoodViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Descripton,
                    RecepieType = x.RecepieType.Name,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    PrepTime = x.PrepTime,
                    CookTime = x.CookTime,
                    Temperature = x.Temperature,
                    TemperatureType = x.TemperatureMeasurment.Name,
                    OvenType = x.OvenType.Name,
                    Origen = x.Origen,
                    TumbsUp = x.TumbsUp,
                    Portions = x.Portions,
                    Owner = x.Owner.UserName,
                    OwnerId = x.OwnerId,
                    })
                .FirstOrDefaultAsync();

            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }

            var ing = await context
                .IngredientFoodRecepies
                .Where(x => x.RecepieId == recepie.Id)
                .Select(x => new Ingredient()
                    {
                    Id = x.IngredientId,
                    Amount = x.Ingredient.Amount,
                    Calories = x.Ingredient.Calories,
                    Name = x.Ingredient.Name,
                    })
                .ToListAsync();

            var steps = await context
                .FoodStepsFoodRecepies
                .Where(x => x.FoodRecepieId == recepie.Id)
                .Select(x => new FoodStep()
                    {
                    Id = x.FoodStep.Id,
                    Description = x.FoodStep.Description,
                    Position = x.FoodStep.Position,
                    })
                .OrderBy(x => x.Position)
                .ToListAsync();

            recepie.Ingredients = ing;
            recepie.Steps = steps;

            return View(recepie);
            }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DetailedFoodViewModel model)
            {
            var recepie = await context.FoodRecepies.FindAsync(model.Id);

            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }


            context.Remove(recepie);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
            }

        [HttpGet]
        public async Task<IActionResult> EditIngredient(int id)
            {
            var recepie = await context
                .IngredientFoodRecepies
                .Where(x => x.IngredientId == id)
                .Select(x => new EditIngredientsForm()
                    {
                    Id = x.IngredientId,
                    Name = x.Ingredient.Name,
                    Description = x.Ingredient.Description,
                    Amount = x.Ingredient.Amount,
                    Calories = x.Ingredient.Calories,
                    MeasurmentId = x.Ingredient.MeasurementId,
                    OwnerId = x.Recepie.OwnerId
                    })
                .FirstOrDefaultAsync();

            recepie.MeasurmentTypes = await GetMeasurmentType();
            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }


            return View(recepie);
            }

        [HttpPost]
        public async Task<IActionResult> EditIngredient(EditIngredientsForm model)
            {
            var recepie = await context
                .IngredientFoodRecepies
                .Include(x => x.Ingredient)
                .Include(x => x.Recepie)
                .Where(x => x.IngredientId == model.Id)
                .FirstOrDefaultAsync();

            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.Recepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }


            recepie.Ingredient.MeasurementId = model.MeasurmentId;
            recepie.Ingredient.Name = model.Name;
            recepie.Ingredient.Amount = model.Amount;
            recepie.Ingredient.Description = model.Description;
            recepie.Ingredient.Calories = model.Calories;

            await context.SaveChangesAsync();

            return RedirectToAction("Detail", new { id = recepie.Recepie.Id });
            }

        [HttpGet]
        public async Task<IActionResult> EditStep(int id)
            {
            var recepie = await context
                .FoodStepsFoodRecepies
                .Where(x => x.FoodStepId == id)
                .Select(x => new EditStepForm()
                    {
                    Id = x.FoodStepId,
                    Description = x.FoodStep.Description,
                    OwnerId = x.FoodRecepie.OwnerId
                    })
                .FirstOrDefaultAsync();

            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }



            return View(recepie);
            }


        [HttpPost]
        public async Task<IActionResult> EditStep(EditStepForm model)
            {
            var recepie = await context
                .FoodStepsFoodRecepies
                .Include(x => x.FoodStep)
                .Include(x => x.FoodRecepie)
                .Where(x => x.FoodStepId == model.Id)
                .FirstOrDefaultAsync();

            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.FoodRecepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }

            recepie.FoodStep.Description = model.Description;

            await context.SaveChangesAsync();

            return RedirectToAction("Detail", new { id = recepie.FoodRecepie.Id });
            }


        /// <summary>
        /// Ajax reqests
        /// It takes the ingreadients and steps form Add recepie and converts it in to the right obj.
        /// </summary>
        /// <param name="allIngredient"></param>
        /// <param name="allSteps"></param>
        /// <returns></returns>

        //if you submit a full form ajax doesnt sends you the bellow data,
        //but if you try to submit only them it does?
        // work around create a separate button to submit the ing and steps
        [HttpPost]
        public JsonResult POSTIngredients(string allIngredient, string allSteps)
            {
            TempIngrediantModel[] ingredientsListDTO = allIngredient.DeserializeFromJson<TempIngrediantModel[]>();
            TempStepModel[] stepListDTO = allSteps.DeserializeFromJson<TempStepModel[]>();

            foreach (var ing in ingredientsListDTO)
                {
                if (ing.Name != null)
                    {
                    Ingredient newIng = new Ingredient()
                        {

                        Name = ing.Name,
                        Amount = ing.Amount,
                        MeasurementId = ing.MeasurementId
                        };

                    addIngredients.Add(newIng);
                    }
                }
            int stepPosition = 1;
            foreach (var step in stepListDTO)
                {
                if (step.Description != null)
                    {
                    FoodStep newStep = new FoodStep()
                        {
                        Position = stepPosition++,
                        Description = step.Description,
                        };

                    addSteps.Add(newStep);
                    }
                }
            //TODO: figure a way to add to the current recepie without creating a global var?!? or not
            return new JsonResult(Ok());
            }

        }
    }
