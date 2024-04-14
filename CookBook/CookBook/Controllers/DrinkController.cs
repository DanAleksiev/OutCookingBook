using CookBook.Core;
using CookBook.Core.Contracts.Services;
using CookBook.Core.DTO;
using CookBook.Core.Models.Drink;
using CookBook.Core.Models.Shared;
using CookBook.Core.Services;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookBook.Controllers
    {
    public class DrinkController : BaseController
        {
        private static List<Ingredient> addIngredients = new List<Ingredient>();
        private static List<Step> addSteps { get; set; } = new List<Step>();

        private readonly IDrinkRecepieService drinkRecepieService;

        public DrinkController(IDrinkRecepieService _drinkRecepieService
            )
            {
            drinkRecepieService = _drinkRecepieService;
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
            ViewBag.Title = "All drink recepies";

            var newQuery = await drinkRecepieService.AllAsync(query, GetUserId());

            return View(newQuery);
            }

        [HttpGet]
        public async Task<IActionResult> Private()
            {
            ViewBag.Title = "Your drink recepies";

            var allRecepies = await drinkRecepieService.PrivateAsync(GetUserId());

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
            var model = await drinkRecepieService.AddGetAsync();

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

            await drinkRecepieService.AddPostAsync(model, GetUserId(), addSteps, addIngredients);
            addIngredients.Clear();
            addSteps.Clear();
            return RedirectToAction("All");
            }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
            {
            if (!await drinkRecepieService.Exist(id))
                {
                return BadRequest();
                }

            if (!await drinkRecepieService.Authorised(id, GetUserId()))
                {
                return Unauthorized();
                }

            var model = await drinkRecepieService.EditGetAsync(id);

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

            if (!await drinkRecepieService.Exist(model.Id))
                {
                return BadRequest(ModelState);
                }

            if (!await drinkRecepieService.Authorised(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

            int recepieId = await drinkRecepieService.EditPostAsync(model);
            return RedirectToAction("Detail", new { id = recepieId });
            }

        [HttpGet]
        public async Task<IActionResult> Detail(int id, string information)
            {
            if (!await drinkRecepieService.Exist(id))
                {
                return BadRequest();
                }

            var recepie = await drinkRecepieService.DetailGetAsync(id, GetUserId());
            return View(recepie);
            }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
            {
            if (!await drinkRecepieService.Exist(id))
                {
                return BadRequest();
                }

            if (!await drinkRecepieService.Authorised(id, GetUserId()))
                {
                return Unauthorized();
                }

            var recepie = await drinkRecepieService.DeleteAsync(id, GetUserId());

            return View(recepie);
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DetailedDrinkViewModel model)
            {
            if (!await drinkRecepieService.Exist(model.Id))
                {
                return BadRequest();
                }

            if (!await drinkRecepieService.Authorised(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

            await drinkRecepieService.ConfirmDeleteAsync(model.Id);

            return RedirectToAction("All");
            }

        [HttpGet]
        public async Task<IActionResult> EditIngredient(int id)
            {
            var recepie = await drinkRecepieService.EditIngredientGetAsync(id);

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
            if (!await drinkRecepieService.ExistIng(model.Id))
                {
                return BadRequest();
                }

            if (!await drinkRecepieService.AuthorisedIng(model.Id, GetUserId()))
                {
                return Unauthorized();
                }
            var recepie = await drinkRecepieService.EditIngredientPostAsync(model);

            return RedirectToAction("Detail", new { id = recepie.Id });
            }

        [HttpGet]
        public async Task<IActionResult> EditStep(int id)
            {
            var recepie = await drinkRecepieService.EditStepGetAsync(id);
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
            if (!await drinkRecepieService.ExistStep(model.Id))
                {
                return BadRequest();
                }

            if (!await drinkRecepieService.AuthorisedStep(model.Id, GetUserId()))
                {
                return Unauthorized();
                }

            var recepie = await drinkRecepieService.EditStepPostAsync(model);

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
