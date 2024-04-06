using CookBook.Core.Models.Shared;

namespace CookBook.Core.Contracts.Services
{
    public interface IRatingService
    {
        Task<bool> AuthorisedFood(int id, string userId);
        Task<bool> ExistFood(int id);
        Task<bool> AuthorisedDrink(int id, string userId);
        Task<bool> ExistDrink(int id);

        Task LikeFood(int id, string userId);
        Task LikeDrink(int id, string userId);

        Task<IEnumerable<AllRecepieViewModel>> TopTenFood();
        Task<IEnumerable<AllRecepieViewModel>> TopTenDrink();
        }
}
