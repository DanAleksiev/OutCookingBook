using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using CookBook.Core.Models.Utilities;
using CookBook.Infrastructures.Data;
using CookBook.Core.Models.Recepies;
using CookBook.Infrastructures.Data.Models.Shared;
using CookBook.Core.Models.Ingredients;
using CookBook.Core;
using CookBook.Core.DTO;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Core.Utilities;

namespace CookBook.Controllers
    {
    [Authorize]
    public class RecepieController : Controller
        {
        private static List<Ingredient> addIngredients = new List<Ingredient>();
        private static List<FoodStep> addSteps { get; set; } = new List<FoodStep>();

        private readonly CookBookDbContext context;
        public RecepieController(CookBookDbContext _context)
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
            var allRecepies = context
                .FoodRecepies
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
                TemperatureTypes = await GetTemperatureType(),
                };

            return View(model);
            }

        [HttpPost]
        public async Task<IActionResult> Add(RecepieViewModel model)
            {
            if (!ModelState.IsValid)
                {
                return View("Add", model);
                }

            var newRecepie = new FoodRecepie()
                {
                Name = model.Name,
                //Steps = addSteps,
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

            var model = new EditRecepieForm()
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
        public async Task<IActionResult> Edit(EditRecepieForm model)
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
            recepie.PrepTime =model.PrepTime;
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

        public IActionResult EditSomeoneOtherRecepie()
            {
            return View();
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

        //ing amount cant be double ?
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
