using CookBook.Core.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookBook.Controllers
    {
    [Authorize]
    public class RatingController : Controller
        {

        private readonly IRatingService ratingService;

        public RatingController(IRatingService _ratingService)
            {
            ratingService = _ratingService;
            }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<IActionResult> FoodLike(int id)
            {
            if (!await ratingService.ExistFood(id))
                {
                return NotFound();
                }

            var userId = GetUserId();
            if (!await ratingService.AuthorisedFood(id, userId))
                {
                return BadRequest();
                }

            await ratingService.LikeFood(id, userId);
            return RedirectToAction("All", "Food");
            }

        public async Task<IActionResult> DrinkLike(int id)
            {
            if (!await ratingService.ExistDrink(id))
                {
                return NotFound();
                }

            var userId = GetUserId();
            if (!await ratingService.AuthorisedDrink(id, userId))
                {
                return BadRequest();
                }

            await ratingService.LikeDrink(id, userId);
            return RedirectToAction("All", "Drink");
            }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TopTenRatedFood()
            {
            var recepis = await ratingService.TopTenFood();

            ViewBag.Title = "Top 10 Food";

            return View(recepis);
            }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TopTenRatedDrink()
            {
            var recepis = await ratingService.TopTenDrink();

            ViewBag.Title = "Top 10 Dinks";

            return View(recepis);
            }


        }
    }
