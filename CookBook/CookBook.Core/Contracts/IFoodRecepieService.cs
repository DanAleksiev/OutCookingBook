using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Core.Services;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Core.Contracts
    {
    public interface IFoodRecepieService
        {
        Task<IEnumerable<UtilTypeModel>> GetMeasurmentTypeAsync();
        Task<IEnumerable<UtilTypeModel>> GetTemperatureTypeAsync();
        Task<IEnumerable<UtilTypeModel>> GetOvenTypeAsync();
        Task<IEnumerable<UtilTypeModel>> GetRecepieTypeAsync();
        Task<bool> Authorised(FoodRecepie? recepie, string userId);
        Task<bool> AuthorisedById(int id, string userId);
        Task<bool> Exist(FoodRecepie? recepie);
        Task<bool> ExistById(int Id);
        Task<IEnumerable<RecepieServiceModel>> TopFiveRecepiesAsync();
        Task<AllRecepieQuerySerciveModel> AllAsync(AllRecepieQuerySerciveModel query, string userId);
        IEnumerable<AllRecepieViewModel> GetLIkesAndFavorites(List<AllRecepieViewModel> allRecepies,string userId);    
        IEnumerable<AllRecepieViewModel> PrivateAsync(string userId);
        Task<FoodViewModel> AddGetAsync();
        Task AddPostAsync(FoodViewModel model, string userId, List<FoodStep> addSteps, List<Ingredient> addIngredients);
        Task<EditFoodForm> EditGetAsync(int id, string userId);
        Task EditPostAsync(EditFoodForm model);
        Task<DetailedFoodViewModel> DetailGetAsync(int id, string userId);
        Task<DetailedFoodViewModel> DeleteAsync(int id, string userId);
        Task ConfirmDeleteAsync(int id);
        Task<EditIngredientsForm> EditIngredientGetAsync(int id);
        Task<int> EditIngredientPostAsync(EditIngredientsForm model);
        Task<EditStepForm> EditStepGepAsync(int id);
        Task<int> EditStepPostAsync(EditStepForm model);

        }
    }