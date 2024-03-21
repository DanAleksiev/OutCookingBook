using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Core.Services;

namespace CookBook.Core.Contracts
    {
    public interface IFoodRecepieService
        {
        Task<IEnumerable<UtilTypeModel>> GetMeasurmentTypeAsync();

        Task<IEnumerable<UtilTypeModel>> GetTemperatureTypeAsync();

        Task<IEnumerable<UtilTypeModel>> GetOvenTypeAsync();

        Task<IEnumerable<UtilTypeModel>> GetRecepieTypeAsync();

        Task<IEnumerable<RecepieServiceModel>> TopFiveRecepiesAsync();

        Task<IEnumerable<DetailedFoodViewModel>> DetailedAsync();
        
        Task<IEnumerable<AllRecepieViewModel>> PrivateAsync();
        Task<IEnumerable<FoodViewModel>> AddSeedOptionsAsync();
        Task<IEnumerable<FoodViewModel>> AddFoodAsync();
        Task<IEnumerable<EditFoodForm>> EditRecepieAsync();
        Task<IEnumerable<EditIngredientsForm>> EditIngredientGetAsync(int id);
        Task<IEnumerable<EditIngredientsForm>> EditIngredientSetAsync(EditIngredientsForm model);
        Task<IEnumerable<EditStepForm>> EditStepGetAsync(int id);
        Task<IEnumerable<EditStepForm>> EditStepSetAsync(EditStepForm model);



        }
    }