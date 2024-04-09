using CookBook.Core.Models.Shared;

namespace CookBook.Core.Contracts.Services
    {
    public interface IFavouriteService
        {
        Task<IEnumerable<AllRecepieViewModel>> FavouriteFood(string userId);
        Task<IEnumerable<AllRecepieViewModel>> FavouriteDrinks(string userId);

        Task FavourFood(int recepieId, string userId);
        Task FavourDrink(int recepieId, string userId);

        Task<bool> ExistFood(int recepieId);
        Task<bool> ExistDrink(int recepieId);

        Task<string> DrinkOwner(int recepieId);
        Task<string> FoodOwner(int recepieId);
        }
    }
