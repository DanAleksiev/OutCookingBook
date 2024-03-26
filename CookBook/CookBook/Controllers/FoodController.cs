using CookBook.Core;
using CookBook.Core.Contracts;
using CookBook.Core.DTO;
using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Services;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookBook.Controllers
    {
    public class FoodController : BaseController
        {
        private static List<Ingredient> addIngredients = new List<Ingredient>();
        private static List<FoodStep> addSteps { get; set; } = new List<FoodStep>();


        private readonly ILogger logger;
        private readonly IFoodRecepieService foodRecepieService;

        public FoodController(
            IFoodRecepieService _foodRecepieService,
            ILogger<FoodController> _logger
            )
            {
            logger = _logger;
            foodRecepieService = _foodRecepieService;
            }


        /// <summary>
        /// Suppoting methods to make my life easier
        /// </summary>
        /// <returns></returns>
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        /// <summary>
        /// Actions from now on
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllRecepieQuerySerciveModel query)
            {
            ViewBag.Title = "All food recepies";

            var newQuery = await foodRecepieService.AllAsync(query, GetUserId());

            return View(newQuery);
            }

        [HttpGet]
        public IActionResult Private()
            {
            ViewBag.Title = "Your food recepies";

            var allRecepies = foodRecepieService.PrivateAsync(GetUserId());

            int count = allRecepies.Count();
            return View("All", new AllRecepieQuerySerciveModel
                {
                Recepies = allRecepies,
                TotalRecepiesCount = count
                });
            }


        [HttpGet]
        public async Task<IActionResult> Add()
            {
            var model = await foodRecepieService.AddGetAsync();

            return View(model);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(FoodViewModel model)
            {
            if (!ModelState.IsValid)
                {
                return View("Add", model);
                }

            await foodRecepieService.AddPostAsync(model, GetUserId(), addSteps, addIngredients);
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
            //var recepie = await context.FoodRecepies.FindAsync(id);

            if (!await foodRecepieService.ExistById(id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.AuthorisedById(id, GetUserId()))
                {
                return Unauthorized();
                }

           var model = await foodRecepieService.EditGetAsync(id, GetUserId());

            return View(model);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditFoodForm model)
            {
            if (!ModelState.IsValid)
                {
                return View("Edit", model);
                }

            if (!await foodRecepieService.ExistById(model.Id))
                {
                return BadRequest(ModelState);
                }

            if (!await foodRecepieService.AuthorisedById(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

           await foodRecepieService.EditPostAsync(model);

            return RedirectToAction("Private");
            }

    

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
            {          
            if (!await foodRecepieService.ExistById(id))
                {
                return BadRequest();
                }

            var recepie = await foodRecepieService.DetailGetAsync(id, GetUserId());
            return View(recepie);
            }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
            {
            if (!await foodRecepieService.ExistById(id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.AuthorisedById(id, GetUserId()))
                {
                return Unauthorized();
                }

            var recepie = foodRecepieService.DeleteAsync(id, GetUserId());

            return View(recepie);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DetailedFoodViewModel model)
            {
            if (!await foodRecepieService.ExistById(model.Id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.AuthorisedById(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

            await foodRecepieService.ConfirmDeleteAsync(model.Id);

            return RedirectToAction("All");
            }

        [HttpGet]
        public async Task<IActionResult> EditIngredient(int id)
            {
            if (!await foodRecepieService.ExistById(id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.AuthorisedById(id, GetUserId()))
                {
                return Unauthorized();
                }
            var recepie = await foodRecepieService.EditIngredientGetAsync(id);

            return View(recepie);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditIngredient(EditIngredientsForm model)
            {
            if (!ModelState.IsValid)
                {
                return View("Edit", model);
                }

            if (!await foodRecepieService.ExistById(model.Id))
                {
                return BadRequest(ModelState);
                }

            if (!await foodRecepieService.AuthorisedById(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

            var recepieId = await foodRecepieService.EditIngredientPostAsync(model);

            return RedirectToAction("Detail", new { id = recepieId });
            }

        [HttpGet]
        public async Task<IActionResult> EditStep(int id)
            {
            if (!await foodRecepieService.ExistById(id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.AuthorisedById(id, GetUserId()))
                {
                return Unauthorized();
                }

            var recepie = await foodRecepieService.EditStepGepAsync(id);

            return View(recepie);
            }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditStep(EditStepForm model)
            {
            var recepie = await foodRecepieService.EditStepPostAsync(model);

            if (!ModelState.IsValid)
                {
                return View("Edit", model);
                }

            if (!await foodRecepieService.ExistById(model.Id))
                {
                return BadRequest(ModelState);
                }

            if (!await foodRecepieService.AuthorisedById(model.Id, GetUserId()))
                {
                return Unauthorized();
                }
            

            return RedirectToAction("Detail", new { id = recepie });
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
