using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using CookBook.Core.Models.Utilities;
using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Models.Shared;
using CookBook.Core;
using CookBook.Core.DTO;
using CookBook.Core.Utilities;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Drink;

namespace CookBook.Controllers
    {
    [Authorize]
    public class DrinkController : BaseController
        {
        private static List<Ingredient> addIngredients = new List<Ingredient>();
        private static List<DrinkStep> addSteps { get; set; } = new List<DrinkStep>();

        private readonly CookBookDbContext context;
        public DrinkController(CookBookDbContext _context)
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


        /// <summary>
        /// Actions from now on
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> All()
            {
            ViewBag.Title = "All drink recepies";



            var allRecepies = await context
                .DrinkRecepies
                .Where(x => !x.IsPrivate)
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    DatePosted = x.DatePosted.ToString("dd/MM/yyyy"),
                    Image = x.Image,
                    TumbsUp = x.TumbsUp,
                    Description = x.Descripton,
                    Owner = x.Owner.UserName,
                    Private = x.IsPrivate
                    })
                .AsNoTracking()
                .ToListAsync();

            var userId = GetUserId();

            var likes = await context
                .DrinkLikeUsers
                .Where(x => x.UserId == userId)
                .ToListAsync();

            foreach (var item in likes)
                {
                allRecepies.First(x => x.Id == item.DrinkRecepieId)
                    .Like = true;
                }

            var favourite = await context
                .FavouriteDrinkRecepiesUsers
                .Where(x => x.UserId == userId)
                .ToListAsync();

            foreach (var i in favourite)
                {
                allRecepies.First(x => x.Id == i.DrinkRecepieId)
                    .Favourite = true;
                }

            return View(allRecepies);
            }

        [HttpGet]
        public async Task<IActionResult> Private()
            {
            ViewBag.Title = "Your drink recepies";

            var allRecepies = await context
                .DrinkRecepies
                .Where(x => x.OwnerId == GetUserId())
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    DatePosted = x.DatePosted.ToString("dd/MM/yyyy"),
                    Image = x.Image,
                    TumbsUp = x.TumbsUp,
                    Description = x.Descripton,
                    Owner = x.Owner.UserName,
                    Private = x.IsPrivate
                    })
                .AsNoTracking()
                .ToListAsync();

            return View("All", allRecepies);
            }


        [HttpGet]
        public async Task<IActionResult> Add()
            {
            var model = new DrinkViewModel()
                {
                MeasurmentTypes = await GetMeasurmentType(),
                };

            return View(model);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(DrinkViewModel model)
            {
            if (!ModelState.IsValid)
                {
                return View("Add", model);
                }

            var newRecepie = new DrinkRecepie()
                {
                Name = model.Name,
                Descripton = model.Description,
                DatePosted = DateTime.Now,
                Image = model.Image,
                Cups = model.Cups,
                Origen = model.Origen,
                OwnerId = GetUserId(),
                IsAlcoholic = model.IsAlcoholic,
                TumbsUp = 0,
                IsPrivate = model.IsPrivate,
                };


            foreach (var step in addSteps)
                {
                var stepRecepie = new DrinkStepDrinkRecepie()
                    {
                    DrinkRecepie = newRecepie,
                    DrinkStep = step,
                    };

                await context.DrinkStep.AddAsync(step);
                await context.DrinkStepsDrinkRecepies.AddAsync(stepRecepie);
                }

            foreach (var ing in addIngredients)
                {

                var ingDrinkRec = new IngredientDrinkRecepie
                    {
                    Ingredient = ing,
                    Recepie = newRecepie
                    };
                await context.Ingredients.AddAsync(ing);
                await context.IngredientDrinkRecepies.AddAsync(ingDrinkRec);
                }

            await context.DrinkRecepies.AddAsync(newRecepie);


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
            var recepie = await context.DrinkRecepies.FindAsync(id);

            
            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }

            var model = new EditDrinkForm()
                {
                Id = recepie.Id,
                Name = recepie.Name,
                Description = recepie.Descripton,
                RecepieTypeId = recepie.Id,
                Image = recepie.Image,
                MeasurmentTypes = await GetMeasurmentType(),
                IsPrivate = recepie.IsPrivate,
                Origen = recepie.Origen,
                Cups = recepie.Cups,
                };

            return View(model);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditDrinkForm model)
            {
            if (!ModelState.IsValid)
                {
                return View("Edit", model);
                }

            var recepie = await context.DrinkRecepies.FindAsync(model.Id);

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
            recepie.IsPrivate = model.IsPrivate;
            recepie.IsAlcoholic = model.IsAlcoholic;
            recepie.Origen = model.Origen;
            recepie.Cups = model.Cups;

            await context.SaveChangesAsync();
            return RedirectToAction("Private");
            }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
            {
            var recepie = await context
                .DrinkRecepies
                .Where(x => x.Id == id)
                .Select(x => new DetailedDrinkViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Descripton,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    Origen = x.Origen,
                    TumbsUp = x.TumbsUp,
                    IsAlcoholic = x.IsAlcoholic,
                    Cups = x.Cups,
                    Owner = x.Owner.UserName,
                    })
                .FirstOrDefaultAsync();


            if (recepie == null)
                {
                return BadRequest();
                }

            var ing = await context
                .IngredientDrinkRecepies
                .Where(x => x.RecepieId == recepie.Id)
                .Select(x => new Ingredient()
                    {
                    Id = x.IngredientId,
                    Amount = x.Ingredient.Amount,
                    Calories = x.Ingredient.Calories,
                    Name = x.Ingredient.Name,
                    Measurement = x.Ingredient.Measurement,
                    })
                .AsNoTracking()
                .ToListAsync();

            var steps = await context
                .DrinkStepsDrinkRecepies
                .Where(x => x.DrinkRecepieId == recepie.Id)
                .Select(x => new DrinkStep()
                    {
                    Id = x.DrinkStep.Id,
                    Description = x.DrinkStep.Description,
                    Position = x.DrinkStep.Position,
                    })
                .OrderBy(x => x.Position)
                .AsNoTracking()
                .ToListAsync();

            var userId = GetUserId();

            var likes = await context
                .DrinkLikeUsers
                .Where(x => x.UserId == userId)
                .ToListAsync();

            foreach (var item in likes)
                {
                if (recepie.Id == item.DrinkRecepieId)
                    {
                    recepie.Like = true;
                    }
                }

            recepie.Ingredients = ing;
            recepie.Steps = steps;
            
            return View(recepie);
            }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
            {
            var recepie = await context
                .DrinkRecepies
                .Where(x => x.Id == id)
                .Select(x => new DetailedDrinkViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Descripton,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    Origen = x.Origen,
                    TumbsUp = x.TumbsUp,
                    Cups = x.Cups,
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
                .IngredientDrinkRecepies
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
                .DrinkStepsDrinkRecepies
                .Where(x => x.DrinkRecepieId == recepie.Id)
                .Select(x => new DrinkStep()
                    {
                    Id = x.DrinkStep.Id,
                    Description = x.DrinkStep.Description,
                    Position = x.DrinkStep.Position,
                    })
                .OrderBy(x => x.Position)
                .ToListAsync();

            recepie.Ingredients = ing;
            recepie.Steps = steps;

            return View(recepie);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DetailedDrinkViewModel model)
            {
            var recepie = await context.DrinkRecepies.FindAsync(model.Id);

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
                .IngredientDrinkRecepies
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
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditIngredient(EditIngredientsForm model)
            {
            var recepie = await context
                .IngredientDrinkRecepies
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
                .DrinkStepsDrinkRecepies
                .Where(x => x.StepId == id)
                .Select(x => new EditStepForm()
                    {
                    Id = x.StepId,
                    Description = x.DrinkStep.Description,
                    OwnerId = x.DrinkRecepie.OwnerId
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
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditStep(EditStepForm model)
            {
            var recepie = await context
                .DrinkStepsDrinkRecepies
                .Include(x => x.DrinkStep)
                .Include(x => x.DrinkRecepie)
                .Where(x => x.StepId == model.Id)
                .FirstOrDefaultAsync();

            if (recepie == null)
                {
                return BadRequest();
                }

            if (recepie.DrinkRecepie.OwnerId != GetUserId())
                {
                return Unauthorized();
                }

            recepie.DrinkStep.Description = model.Description;

            return RedirectToAction("Detail", new { id = recepie.DrinkRecepie.Id });
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
        public JsonResult PostIngredients(string allIngredient, string allSteps)
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
                    DrinkStep newStep = new DrinkStep()
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
