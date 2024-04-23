using CookBook.Core;
using CookBook.Core.Contracts.Services;
using CookBook.Core.DTO;
using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Services;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookBook.Controllers
    {
    public class FoodController : BaseController
        {
        private static List<Ingredient> addIngredients = new List<Ingredient>();
        private static List<Step> addSteps { get; set; } = new List<Step>();


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
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllRecepieQuerySerciveModel query)
            {
            ViewBag.Title = "All food recepies";

            var newQuery = await foodRecepieService.AllAsync(query, GetUserId());

            return View(newQuery);
            }

        [HttpGet]
        public async Task<IActionResult> Private()
            {
            ViewBag.Title = "Your food recepies";

            var allRecepies = await foodRecepieService.PrivateAsync(GetUserId());

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
            {
            if (!await foodRecepieService.Exist(id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.Authorised(id, GetUserId()))
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

            if (!await foodRecepieService.Exist(model.Id))
                {
                return BadRequest(ModelState);
                }

            if (!await foodRecepieService.Authorised(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

            int recepieId = await foodRecepieService.EditPostAsync(model);
            return RedirectToAction("Detail", new { id = recepieId });
            }



        [HttpGet]
        public async Task<IActionResult> Detail(int id)
            {
            if (!await foodRecepieService.Exist(id))
                {
                return BadRequest();
                }

            var recepie = await foodRecepieService.DetailGetAsync(id, GetUserId());
            return View(recepie);
            }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
            {
            if (!await foodRecepieService.Exist(id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.Authorised(id, GetUserId()))
                {
                return Unauthorized();
                }

            var recepie = await foodRecepieService.DeleteAsync(id, GetUserId());

            return View(recepie);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DetailedFoodViewModel model)
            {
            if (!await foodRecepieService.Exist(model.Id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.Authorised(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

            await foodRecepieService.ConfirmDeleteAsync(model.Id);

            return RedirectToAction("All");
            }

        [HttpGet]
        public async Task<IActionResult> EditIngredient(int id)
            {
            var recepie = await foodRecepieService.EditIngredientGetAsync(id);

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
            if (!ModelState.IsValid)
                {
                return View("EditIngredient", model);
                }
            if (!await foodRecepieService.ExistIng(model.Id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.AuthorisedIng(model.Id, GetUserId()))
                {
                return Unauthorized();
                }
            var recepie = await foodRecepieService.EditIngredientPostAsync(model);

            return RedirectToAction("Detail", new { id = recepie.Id });
            }

        [HttpGet]
        public async Task<IActionResult> EditStep(int id)
            {
            var recepie = await foodRecepieService.EditStepGetAsync(id);
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
            if (!ModelState.IsValid)
                {
                return View("EditStep", model);
                }

            //the verification is after the saveDatabase so its pointless
            if (!await foodRecepieService.ExistStep(model.Id))
                {
                return BadRequest();
                }

            if (!await foodRecepieService.AuthorisedStep(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

            var recepie = await foodRecepieService.EditStepPostAsync(model);

            return RedirectToAction("Detail", new { id = recepie.Id });
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
        public JsonResult PostIngredientsFood(string allIngredient, string allSteps)
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
                    Step newStep = new Step()
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
