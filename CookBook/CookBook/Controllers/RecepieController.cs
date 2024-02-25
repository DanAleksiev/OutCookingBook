using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using CookBook.Core.Models.Utilities;
using CookBook.Infrastructures.Data;
using CookBook.Core.Models.Recepies;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Controllers
    {
    [Authorize]
    public class RecepieController : Controller
        {
        private readonly CookBookDbContext context;
        public RecepieController(CookBookDbContext _context)
            {
            context = _context;
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

        //public IActionResult AddIngredientPartial()
        //    {
        //    return PartialView("_AddIngredientPartial");
        //    }

        [HttpGet]
        public async Task<IActionResult> Add() 
            {
            var model = new RecepieViewModel()
                {
                RecepieTypes = await GetRecepieType(),
                OvenTypes = await GetOvenType(),
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

            return RedirectToAction();
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


        // ajax
        //[HttpGet]
        //public JsonResult GetNames()
        //    {
        //    var names = new string[3]
        //        {
        //        "clara",
        //        "mark",
        //        "judy"
        //        };

        //    return new JsonResult(Ok(names));
        //    }


        [HttpPost]
        public JsonResult PostNames(string names)
            {

            return new JsonResult(Ok());
            }

        }
    }
