using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Core.Services;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Core.Contracts
    {
    public interface IFoodRecepieService
        {
        Task<IEnumerable<UtilTypeModel>> GetMeasurmentTypeAsync();
        Task<IEnumerable<UtilTypeModel>> GetTemperatureTypeAsync();
        Task<IEnumerable<UtilTypeModel>> GetOvenTypeAsync();
        Task<IEnumerable<UtilTypeModel>> GetRecepieTypeAsync();
        IEnumerable<AllRecepieViewModel> GetLIkesAndFavoritesMany(List<AllRecepieViewModel> allRecepies,string userId);
       //and this
        Task<DetailedFoodViewModel> GetLIkesAndFavorites(DetailedFoodViewModel recepie, string userId);


        Task<IEnumerable<AllRecepieViewModel>> TopFiveRecepiesAsync();
        Task<AllRecepieQuerySerciveModel> AllAsync(AllRecepieQuerySerciveModel query, string userId);
        IEnumerable<AllRecepieViewModel> PrivateAsync(string userId);
        //from here
        Task<FoodViewModel> AddGetAsync();
        Task AddPostAsync(FoodViewModel model, string userId, List<FoodStep> addSteps, List<Ingredient> addIngredients);
        Task<EditFoodForm> EditGetAsync(int id, string userId);
        Task EditPostAsync(EditFoodForm model);
        //to here is unique pull it to a separate Interface specified for food and implement it along this one,
        //rename this to something like base interface 
        Task<DetailedFoodViewModel> DetailGetAsync(int id, string userId);
        Task<DetailedFoodViewModel> DeleteAsync(int id, string userId);
        Task ConfirmDeleteAsync(int id);
        Task<EditIngredientsForm> EditIngredientGetAsync(int id);
        Task<EditIngredientsForm> EditIngredientPostAsync(EditIngredientsForm model);
        Task<EditStepForm> EditStepGetAsync(int id);
        Task<EditStepForm> EditStepPostAsync(EditStepForm model);


        Task<bool> Authorised(int id, string userId);
        Task<bool> Exist(int Id);
        Task<bool> AuthorisedStep(int id, string userId);
        Task<bool> ExistStep(int Id);
        Task<bool> AuthorisedIng(int id, string userId);
        Task<bool> ExistIng(int Id);
        }
    }