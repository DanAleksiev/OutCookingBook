using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CookBook.Controllers
    {

    public class RatingController : BaseController
        {

        private readonly CookBookDbContext context;
        public RatingController(CookBookDbContext _context)
            {
            context = _context;
            }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<IActionResult> FoodLike(int id)
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
                .FoodLikeUsers
                .Where(x => x.UserId == userId && x.FoodRecepieId == recepie.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var like = new FoodLikeUser
                {
                FoodRecepieId = recepie.Id,
                UserId = userId
                };

            if (existing != null)
                {
                recepie.TumbsUp--;

                context.FoodLikeUsers.Remove(like);
                await context.SaveChangesAsync();

                return RedirectToAction("All", "Food");
                }

        
            recepie.TumbsUp++;
            await context.FoodLikeUsers.AddAsync(like);
                await context.SaveChangesAsync();


            return Ok();
            }

        public async Task<IActionResult> DrinkLike(int id)
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
                .DrinkLikeUsers
                .Where(x => x.UserId == userId && x.DrinkRecepieId == recepie.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var like = new DrinkLikeUser
                {
                DrinkRecepieId = recepie.Id,
                UserId = userId
                };


            if (existing != null)
                {
                recepie.TumbsUp--;

                context.DrinkLikeUsers.Remove(like);
                await context.SaveChangesAsync();

                return RedirectToAction("All", "Drink");
                }

       
            recepie.TumbsUp++;

            await context.DrinkLikeUsers.AddAsync(like);
            await context.SaveChangesAsync();

            return RedirectToAction("All", "Drink");
            }

        }
    }
