using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Core.Services;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Core.Contracts.Services
{
    public interface IFoodRecepieService : IRecepieService
    {
        Task<IEnumerable<UtilTypeModel>> GetTemperatureTypeAsync();
        Task<IEnumerable<UtilTypeModel>> GetOvenTypeAsync();
        Task<IEnumerable<UtilTypeModel>> GetRecepieTypeAsync();
        Task<DetailedFoodViewModel> GetLIkesAndFavorites(DetailedFoodViewModel recepie, string userId);

        Task<FoodViewModel> AddGetAsync();
        Task AddPostAsync(FoodViewModel model, string userId, List<Step> addSteps, List<Ingredient> addIngredients);
        Task<EditFoodForm> EditGetAsync(int id, string userId);
        Task<int> EditPostAsync(EditFoodForm model);


        Task<DetailedFoodViewModel> DetailGetAsync(int id, string userId);
        Task<DetailedFoodViewModel> DeleteAsync(int id, string userId);

    }
}