using CookBook.Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookBook.Controllers
{
    public class FavouriteController : BaseController
        {
        private readonly IFavouriteService favouriteService;

        public FavouriteController(IFavouriteService _favouriteService)
            {
            favouriteService = _favouriteService;
            }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<IActionResult> FavouriteFood(int id)
            {
            if (!await favouriteService.ExistFood(id))
                {
                return NotFound();
                }

            var userId = GetUserId();
            var ownerId = await favouriteService.FoodOwner(id);
            if (ownerId == userId)
                {
                return BadRequest();
                }

            await favouriteService.FavourFood(id, userId);
            return RedirectToAction("All", "Food");
            }

        public async Task<IActionResult> FavouriteDrink(int id)
            {
            if (!await favouriteService.ExistDrink(id))
                {
                return NotFound();
                }

            var userId = GetUserId();
            var ownerId = await favouriteService.DrinkOwner(id);
            if (ownerId == userId)
                {
                return BadRequest();
                }

            await favouriteService.FavourDrink(id, userId);
            return RedirectToAction("All", "Drink");
            }

        [HttpGet]
        public async Task<IActionResult> AllFavouriteFood()
            {
            var userId = GetUserId();
            var existing = await favouriteService.FavouriteFood(userId);

            return View(existing);
            }

        [HttpGet]
        public async Task<IActionResult> AllFavouriteDrink()
            {
            var userId = GetUserId();
            var existing = await favouriteService.FavouriteDrinks(userId);

            return View(existing);
            }       
        }
    }