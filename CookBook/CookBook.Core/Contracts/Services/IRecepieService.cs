using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Core.Services;

namespace CookBook.Core.Contracts.Services
    {
    public interface IRecepieService
        {
        Task<IEnumerable<UtilTypeModel>> GetMeasurmentTypeAsync();
        IEnumerable<AllRecepieViewModel> GetLIkesAndFavoritesMany(List<AllRecepieViewModel> allRecepies, string userId);
        Task<AllRecepieQuerySerciveModel> AllAsync(AllRecepieQuerySerciveModel query, string userId);
        Task<IEnumerable<AllRecepieViewModel>> PrivateAsync(string userId);

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
