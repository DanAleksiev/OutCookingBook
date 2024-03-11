using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CookBook.Controllers
    {
    public class FavouriteController : BaseController
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

            var like = new FavouriteFoodRecepiesUsers
                {
                FoodRecepieId = recepie.Id,
                UserId = userId
                };

            if (existing != null)
                {
                recepie.TumbsUp--;
                context.FavouriteFoodRecepiesUsers.Remove(like);
                }
            else
                {
                recepie.TumbsUp++;
                await context.FavouriteFoodRecepiesUsers.AddAsync(like);
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

            var like = new FavouriteDrinkRecepiesUsers
                {
                DrinkRecepieId = recepie.Id,
                UserId = userId
                };


            if (existing != null)
                {
                recepie.TumbsUp--;
                context.FavouriteDrinkRecepiesUsers.Remove(like);
                }
            else
                {
                recepie.TumbsUp++;
                await context.FavouriteDrinkRecepiesUsers.AddAsync(like);
                }

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Drink");
            }
        }
    }
