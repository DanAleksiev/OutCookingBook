using CookBook.Core.Models.Drink;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Core.Services;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Core.Contracts
    {
    public interface IDrinkRecepieService: IRecepieService
        {

        Task<DetailedDrinkViewModel> GetLIkesAndFavorites(DetailedDrinkViewModel recepie, string userId);

        //from here
        Task<DrinkViewModel> AddGetAsync();
        Task AddPostAsync(DrinkViewModel model, string userId, List<Step> addSteps, List<Ingredient> addIngredients);
        Task<EditDrinkForm> EditGetAsync(int id, string userId);
        Task<int> EditPostAsync(EditDrinkForm model);

        Task<DetailedDrinkViewModel> DetailGetAsync(int id, string userId);
        Task<DetailedDrinkViewModel> DeleteAsync(int id, string userId);

        }
    }