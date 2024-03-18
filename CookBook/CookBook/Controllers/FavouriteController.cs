using CookBook.Core.Models.Shared;
using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CookBook.Controllers
    {
    [Authorize]
    public class FavouriteController : Controller
        {
        private readonly CookBookDbContext context;
        public FavouriteController(CookBookDbContext _context)
            {
            context = _context;
            }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<IActionResult> FavouriteFood(int id)
            {
            var userId = GetUserId();

            var recepie = await context
                .FoodRecepies
                .FindAsync(id);

            if (recepie == null)
                {
                return NotFound();
                }

            if (recepie.OwnerId == userId)
                {
                return BadRequest();
                }

            var existing = await context
                .FavouriteFoodRecepiesUsers
                .Where(x => x.UserId == userId && x.FoodRecepieId == recepie.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var favourite = new FavouriteFoodRecepiesUsers
                {
                FoodRecepieId = recepie.Id,
                UserId = userId
                };

            if (existing != null)
                {
                context.FavouriteFoodRecepiesUsers.Remove(favourite);
                }
            else
                {
                await context.FavouriteFoodRecepiesUsers.AddAsync(favourite);
                }

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Food");
            }

        public async Task<IActionResult> FavouriteDrink(int id)
            {
            var userId = GetUserId();

            var recepie = await context
                .DrinkRecepies
                .FindAsync(id);

            if (recepie == null)
                {
                return NotFound();
                }

            if (recepie.OwnerId == userId)
                {
                return BadRequest();
                }

            var existing = await context
                .FavouriteDrinkRecepiesUsers
                .Where(x =>
                    x.UserId == userId
                    && x.DrinkRecepieId == recepie.Id
                    && x.UserId == GetUserId())
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var favourite = new FavouriteDrinkRecepiesUsers
                {
                DrinkRecepieId = recepie.Id,
                UserId = userId
                };


            if (existing != null)
                {
                context.FavouriteDrinkRecepiesUsers.Remove(favourite);
                }
            else
                {
                await context.FavouriteDrinkRecepiesUsers.AddAsync(favourite);
                }

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Drink");
            }

        [HttpGet]
        public async Task<IActionResult> AllFavouriteFood()
            {
            var userId = GetUserId();
            var existing = await context
                .FavouriteFoodRecepiesUsers
                .Where(x => x.UserId == userId)
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.FoodRecepie.Id,
                    Name = x.FoodRecepie.Name,
                    DatePosted = x.FoodRecepie.DatePosted,
                    Image = x.FoodRecepie.Image,
                    Owner = x.FoodRecepie.Owner.UserName,
                    TumbsUp = x.FoodRecepie.TumbsUp,
                    Description = x.FoodRecepie.Descripton,
                    })
                .AsNoTracking()
                .ToListAsync();

            return View(existing);
            }

        [HttpGet]
        public async Task<IActionResult> AllFavouriteDrink()
            {
            var userId = GetUserId();
            var existing = await context
                .FavouriteDrinkRecepiesUsers
                .Where(x => x.UserId == userId)
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.DrinkRecepie.Id,
                    Name = x.DrinkRecepie.Name,
                    DatePosted = x.DrinkRecepie.DatePosted,
                    Image = x.DrinkRecepie.Image,
                    Owner = x.DrinkRecepie.Owner.UserName,
                    TumbsUp = x.DrinkRecepie.TumbsUp,
                    Description = x.DrinkRecepie.Descripton,
                    })
                .AsNoTracking()
                .ToListAsync();

            return View(existing);
            }


        }
    }
