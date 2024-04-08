using CookBook.Core.Contracts;
using CookBook.Core.Contracts.Services;
using CookBook.Core.Models.Shared;
using CookBook.Infrastructures.Data.Common;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Core.Services
    {
    public class RatingService : IRatingService
        {
        private readonly IRepository repository;

        public RatingService(IRepository _repository)
            {
            repository = _repository;
            }

        public async Task<bool> AuthorisedDrink(int id, string userId)
            {
            return await repository
                .AllReadOnly<DrinkRecepie>()
                .AnyAsync(x => x.Id == id && x.OwnerId != userId);

            }

        public async Task<bool> AuthorisedFood(int id, string userId)
            {
            return await repository
                .AllReadOnly<FoodRecepie>()
                .AnyAsync(x => x.Id == id && x.OwnerId != userId);
            }

        public async Task<bool> ExistDrink(int id)
            {
            return await repository
                .AllReadOnly<DrinkRecepie>()
                .AnyAsync(x => x.Id == id);
            }

        public async Task<bool> ExistFood(int id)
            {
            return await repository
                .AllReadOnly<FoodRecepie>()
                .AnyAsync(x => x.Id == id);
            }

        public async Task LikeDrink(int id, string userId)
            {
            var recepie = await repository
                .GetByIdAsync<DrinkRecepie>(id);

            var existing = await repository
                .All<DrinkLikeUser>()
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
                await repository.DeleteElementAsync(like);
                }
            else
                {
                recepie.TumbsUp++;
                await repository.AddAsync(like);
                }

            await repository.SaveChangesAsync();
            }

        public async Task LikeFood(int id, string userId)
            {
            var recepie = await repository
                .GetByIdAsync<FoodRecepie>(id);

            var existing = await repository
                .All<FoodLikeUser>()
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
                await repository.DeleteElementAsync(like);
                }
            else
                {
                recepie.TumbsUp++;
                await repository.AddAsync(like);
                }

            await repository.SaveChangesAsync();
            }

        public async Task<IEnumerable<AllRecepieViewModel>> TopTenDrink()
            {
            return await repository
                .AllReadOnly<DrinkRecepie>()
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
            }

        public async Task<IEnumerable<AllRecepieViewModel>> TopTenFood()
            {
            return await repository
                .AllReadOnly<FoodRecepie>()
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
            }
        }
    }
