using CookBook.Areas.Admin.Controllers;
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
    public class RatingController : Controller
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
                }
            else
                {
                recepie.TumbsUp++;
                await context.FoodLikeUsers.AddAsync(like);
                }

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Food");
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
                }
            else
                {
                recepie.TumbsUp++;
                await context.DrinkLikeUsers.AddAsync(like);
                }

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Drink");
            }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TopTenRatedFood()
            {
            var recepis = await context
                .FoodRecepies
                .OrderByDescending(x => x.TumbsUp)
                .Where(x => !x.IsPrivate && x.TumbsUp > 0)
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    TumbsUp = x.TumbsUp,
                    Description = x.Descripton,
                    Owner = x.Owner.UserName,
                    Private = x.IsPrivate
                    })
                .Take(10)
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Title = "Top 10 Food";

            return View(recepis);
            }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TopTenRatedDrink()
            {
            var recepis = await context
                .DrinkRecepies
                .OrderByDescending(x => x.TumbsUp)
                .Where(x => !x.IsPrivate && x.TumbsUp > 0)
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    TumbsUp = x.TumbsUp,
                    Description = x.Descripton,
                    Owner = x.Owner.UserName,
                    Private = x.IsPrivate
                    })
                .Take(10)
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Title = "Top 10 Dinks";

            return View(recepis);
            }


        }
    }
