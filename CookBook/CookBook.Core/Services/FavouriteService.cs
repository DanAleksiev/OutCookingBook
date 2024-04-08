using CookBook.Core.Contracts.Services;
using CookBook.Core.Models.Shared;
using CookBook.Infrastructures.Data.Common;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Core.Services
{
    public class FavouriteService : IFavouriteService
        {
        private readonly IRepository repository;
        public FavouriteService(IRepository _repository)
            {
            repository = _repository;
            }

        public async Task<string> DrinkOwner(int recepieId)
            {
            var owner = await repository
                .AllReadOnly<DrinkRecepie>()
                .Where(r => r.Id == recepieId)
                .FirstAsync();

            return owner.OwnerId;
            }

        public async Task<string> FoodOwner(int recepieId)
            {
            var owner = await repository
                .AllReadOnly<FoodRecepie>()
                .Where(r => r.Id == recepieId)
                .FirstAsync();

            return owner.OwnerId;
            }

        public async Task FavourDrink(int recepieId, string userId)
            {
            var existing = await repository
                .AllReadOnly<FavouriteDrinkRecepiesUsers>()
                .Where(x => x.UserId == userId && x.DrinkRecepieId == recepieId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var favourite = new FavouriteDrinkRecepiesUsers
                {
                DrinkRecepieId = recepieId,
                UserId = userId,
                };

            if (existing != null)
                {
                await repository.DeleteAsync<FavouriteFoodRecepiesUsers>(favourite);
                }
            else
                {
                await repository.AddAsync(favourite);
                }

            await repository.SaveChangesAsync();
            }

        public async Task FavourFood(int recepieId, string userId)
            {
            var existing = await repository
                .AllReadOnly<FavouriteFoodRecepiesUsers>()
                .Where(x => x.UserId == userId && x.FoodRecepieId == recepieId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var favourite = new FavouriteFoodRecepiesUsers
                {
                FoodRecepieId = recepieId,
                UserId = userId,
                };

            if (existing != null)
                {
                await repository.DeleteAsync<FavouriteFoodRecepiesUsers>(favourite);
                }
            else
                {
                await repository.AddAsync(favourite);
                }

            await repository.SaveChangesAsync();
            }

        public async Task<IEnumerable<AllRecepieViewModel>> FavouriteDrinks(string userId)
            {
            var existing = await repository
                .AllReadOnly<FavouriteDrinkRecepiesUsers>()
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
            try
                {
                await GetLikesAndFavForDrinks(userId, existing);
                }
            catch { }
            return existing;
            }

        public async Task<IEnumerable<AllRecepieViewModel>> FavouriteFood(string userId)
            {
            var existing = await repository
                .AllReadOnly<FavouriteFoodRecepiesUsers>()
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
            try
                {
                await GetLikesAndFavForFood(userId, existing);
                }
            catch { }
            return existing;
            }

        public async Task<bool> ExistFood(int recepieId)
            {
            return await repository
                .AllReadOnly<FoodRecepie>()
                .AnyAsync(r => r.Id == recepieId);
            }

        public async Task<bool> ExistDrink(int recepieId)
            {
            return await repository
                .AllReadOnly<DrinkRecepie>()
                .AnyAsync(r => r.Id == recepieId);
            }

        private async Task<IEnumerable<AllRecepieViewModel>> GetLikesAndFavForFood(string userId, IEnumerable<AllRecepieViewModel> recepies)
            {
            var likes = await repository
                .AllReadOnly<FoodLikeUser>()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            foreach (var i in likes)
                {
                recepies.First(x => x.Id == i.FoodRecepieId)
                    .Like = true;
                }

            var favourite = await repository
                .All<FavouriteFoodRecepiesUsers>()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            foreach (var i in favourite)
                {
                recepies.First(x => x.Id == i.FoodRecepieId)
                    .Favourite = true;
                }

            return recepies;
            }

        private async Task<IEnumerable<AllRecepieViewModel>> GetLikesAndFavForDrinks(string userId, IEnumerable<AllRecepieViewModel> recepies)
            {
            var likes = await repository
                .AllReadOnly<DrinkLikeUser>()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            foreach (var i in likes)
                {
                recepies.First(x => x.Id == i.DrinkRecepieId)
                    .Like = true;
                }

            var favourite = await repository
                .All<FavouriteDrinkRecepiesUsers>()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            foreach (var i in favourite)
                {
                recepies.First(x => x.Id == i.DrinkRecepieId)
                    .Favourite = true;
                }

            return recepies;
            }
        }
    }
