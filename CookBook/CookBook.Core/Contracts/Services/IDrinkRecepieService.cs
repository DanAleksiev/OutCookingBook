﻿using CookBook.Core.Models.Drink;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Core.Contracts.Services
    {
    public interface IDrinkRecepieService : IRecepieService
        {

        Task<DetailedDrinkViewModel> GetLIkesAndFavorites(DetailedDrinkViewModel recepie, string userId);

        Task<DrinkViewModel> AddGetAsync();
        Task AddPostAsync(DrinkViewModel model, string userId, List<Step> addSteps, List<Ingredient> addIngredients);
        Task<EditDrinkForm> EditGetAsync(int id);
        Task<int> EditPostAsync(EditDrinkForm model);

        Task<DetailedDrinkViewModel> DetailGetAsync(int id, string userId);
        Task<DetailedDrinkViewModel> DeleteAsync(int id, string userId);

        }
    }