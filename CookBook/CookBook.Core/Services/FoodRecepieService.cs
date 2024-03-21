using CookBook.Core.Contracts;
using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Infrastructures.Data.Common;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Core.Services
    {
    public class FoodRecepieService : IFoodRecepieService
        {
        private IRepository repository;

        public FoodRecepieService(IRepository repository)
            {
            this.repository = repository;
            }

        public async Task<IEnumerable<UtilTypeModel>> GetMeasurmentTypeAsync()
            {
            return await repository
                .AllReadOnly<Measurement>()
                .Select(m => new UtilTypeModel()
                    {
                    Id = m.Id,
                    Name = m.Name,
                })
                .ToListAsync();
            }

        public async Task<IEnumerable<UtilTypeModel>> GetTemperatureTypeAsync()
            {
            return await repository
                .AllReadOnly<TemperatureMeasurment>()
                .Select(t => new UtilTypeModel()
                    {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
            }
        public async Task<IEnumerable<UtilTypeModel>> GetOvenTypeAsync()
            {
            return await repository
                .AllReadOnly<OvenType>()
                .Select(t => new UtilTypeModel()
                    {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync(); ;
            }
        public async Task<IEnumerable<UtilTypeModel>> GetRecepieTypeAsync()
            {
            return await repository
                .AllReadOnly<RecepieType>()
                .Select(t => new UtilTypeModel()
                    {
                    Id = t.Id,
                    Name = t.Name,
                    })
                .ToListAsync();
            }

        public async Task<IEnumerable<RecepieServiceModel>> TopFiveRecepiesAsync()
            {
            return await repository
                .AllReadOnly<FoodRecepie>()
                .Take(5)
                .Select(r => new RecepieServiceModel()
                    {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Descripton,
                    Image = r.Image,
                    Owner = r.Owner.UserName,
                    TumbsUp = r.TumbsUp,
                    DatePosted = r.DatePosted,
                    })
                .OrderByDescending(x=> x.TumbsUp)
                .ToListAsync();
            }

        public Task<IEnumerable<DetailedFoodViewModel>> DetailedAsync()
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<AllRecepieViewModel>> PrivateAsync()
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<FoodViewModel>> AddFillGetAsync()
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<FoodViewModel>> AddFoodAsync()
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<EditFoodForm>> EditAsync()
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<FoodViewModel>> AddSeedOptionsAsync()
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<EditFoodForm>> EditRecepieAsync()
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<EditIngredientsForm>> EditIngredientGetAsync(int id)
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<EditIngredientsForm>> EditIngredientSetAsync(EditIngredientsForm model)
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<EditStepForm>> EditStepGetAsync(int id)
            {
            throw new NotImplementedException();
            }

        public Task<IEnumerable<EditStepForm>> EditStepSetAsync(EditStepForm model)
            {
            throw new NotImplementedException();
            }
        }
}
