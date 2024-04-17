using CookBook.Core.Contracts.Services;
using CookBook.Core.Enum;
using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Core.Utilities;
using CookBook.Infrastructures.Data.Common;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Core.Services
    {
    public class FoodRecepieService : IFoodRecepieService
        {
        private readonly IRepository repository;

        public FoodRecepieService(IRepository _repository)
            {
            repository = _repository;
            }

        /// <summary>
        /// Veryfication and Authorisation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<bool> Authorised(int id, string userId)
            {
            return await repository
                 .AllReadOnly<FoodRecepie>()
                 .Where(r => r.Id == id)
                 .AllAsync(x => x.OwnerId == userId);
            }

        public async Task<bool> Exist(int id)
            {
            return await repository
                .AllReadOnly<FoodRecepie>()
                .AnyAsync(r => r.Id == id);
            }

        public async Task<bool> AuthorisedStep(int id, string userId)
            {
            return await repository
                 .AllReadOnly<FoodRecepie>()
                 .Where(r => r.IngredientsRecepies.Any(i => i.IngredientId == id))
                 .AllAsync(x => x.OwnerId == userId);
            }

        public async Task<bool> ExistStep(int id)
            {
            return await repository
                .AllReadOnly<Step>()
                .AnyAsync(r => r.Id == id);
            }

        public async Task<bool> AuthorisedIng(int id, string userId)
            {
            return await repository
                 .AllReadOnly<FoodRecepie>()
                 .Where(r => r.Steps.Any(i => i.FoodStepId == id))
                 .AllAsync(x => x.OwnerId == userId);
            }

        public async Task<bool> ExistIng(int id)
            {
            return await repository
                .AllReadOnly<Ingredient>()
                .AnyAsync(r => r.Id == id);
            }

        /// <summary>
        /// Helpers
        /// </summary>
        /// <returns></returns>

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

        public IEnumerable<AllRecepieViewModel> GetLIkesAndFavoritesMany(List<AllRecepieViewModel> allRecepies, string userId)
            {

            var likes = repository
                .AllReadOnly<FoodLikeUser>()
                .Where(x => x.UserId == userId)
                .ToList();

            foreach (var i in likes)
                {
                if (allRecepies.Any(x => x.Id == i.FoodRecepieId))
                    {
                    allRecepies.First(x => x.Id == i.FoodRecepieId)
                    .Like = true;
                    }
                }

            var favourite = repository
                .AllReadOnly<FavouriteFoodRecepiesUsers>()
                .Where(x => x.UserId == userId)
                .ToList();

            foreach (var i in favourite)
                {
                if (allRecepies.Any(x => x.Id == i.FoodRecepieId))
                    {
                    allRecepies.FirstOrDefault(x => x.Id == i.FoodRecepieId)
                    .Favourite = true;
                    }
                }

            return allRecepies;
            }

        public async Task<DetailedFoodViewModel> GetLIkesAndFavorites(DetailedFoodViewModel recepie, string userId)
            {

            var likes = await repository
                .AllReadOnly<FoodLikeUser>()
                .Where(x => x.UserId == userId && x.FoodRecepieId == recepie.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (likes != null)
                {
                recepie.Like = true;
                }

            var favourite = await repository
                .AllReadOnly<FavouriteFoodRecepiesUsers>()
                .Where(x => x.UserId == userId && x.FoodRecepieId == recepie.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (favourite != null)
                {
                recepie.Favourite = true;
                }


            return recepie;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public async Task<FoodViewModel> AddGetAsync()
            {
            return new FoodViewModel()
                {
                RecepieTypes = await GetRecepieTypeAsync(),
                OvenTypes = await GetOvenTypeAsync(),
                MeasurmentTypes = await GetMeasurmentTypeAsync(),
                TemperatureTypes = await GetTemperatureTypeAsync(),
                };
            }

        public async Task<AllRecepieQuerySerciveModel> AllAsync(AllRecepieQuerySerciveModel query, string userId)
            {
            var targetRec = await repository
                .AllReadOnly<FoodRecepie>()
                .Include(t => t.Owner)
                .Include(t => t.IngredientsRecepies)
                .ThenInclude(t => t.Ingredient)
                .Where(x =>
                !x.IsPrivate)
                .AsNoTracking()
                .ToListAsync();

            string searching = query.Searching.ToString();

            if (query.SearchTerm != null)
                {
                string term = query.SearchTerm.ToLower();

                if (searching == SearchFieldsEnum.Name.ToString())
                    {
                    targetRec = targetRec
                        .Where(r =>
                        r.Name
                        .ToLower()
                        .Contains(term))
                        .ToList();
                    }
                else
                    {
                    targetRec = targetRec.Where(r =>
                    r.IngredientsRecepies
                    .Any(i =>
                        i.Ingredient.Name.ToLower()
                        .Contains(term)))
                     .ToList();
                    }
                }

            var sort = query.Sorting;
            targetRec = sort switch
                {
                    SortingFieldsEnum.Name => targetRec
                    .OrderBy(r => r.Name)
                    .ToList(),
                    SortingFieldsEnum.Newest => targetRec
                    .OrderByDescending(r => r.DatePosted)
                    .ToList(),
                    SortingFieldsEnum.Oldest => targetRec
                    .OrderBy(r => r.DatePosted)
                    .ToList(),
                    SortingFieldsEnum.TumbsUp => targetRec
                    .OrderByDescending(r => r.TumbsUp)
                    .ToList(),
                    SortingFieldsEnum.PrepTime => targetRec
                    .OrderBy(r => r.PrepTime)
                    .ToList(),
                    SortingFieldsEnum.CookTime => targetRec
                    .OrderBy(r => r.CookTime)
                    .ToList(),
                    _ => targetRec
                    .OrderBy(r => r.Id)
                    .ToList(),

                    };

            int currentPage = query.CurrentPage;
            int recepiesPerPage = query.RecepiesPerPage;

            var allRecepies = targetRec
                .Skip((currentPage - 1) * recepiesPerPage)
                .Take(recepiesPerPage)
                .Select(r => new AllRecepieViewModel()
                    {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    Image = r.Image,
                    Owner = r.Owner.UserName,
                    TumbsUp = r.TumbsUp,
                    DatePosted = r.DatePosted,
                    })
                .ToList();

            try
                {
                allRecepies = GetLIkesAndFavoritesMany(allRecepies, userId).ToList();
                }
            catch { }

            query.Recepies = allRecepies;
            query.TotalRecepiesCount = targetRec.Count();

            return query;
            }

        public async Task<IEnumerable<AllRecepieViewModel>> PrivateAsync(string userId)
            {
            var allRecepies = await repository
                .AllReadOnly<FoodRecepie>()
                .Where(x => x.OwnerId == userId)
                .Select(x => new AllRecepieViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    TumbsUp = x.TumbsUp,
                    Description = x.Description,
                    Owner = x.Owner.UserName,
                    Private = x.IsPrivate
                    })
                .AsNoTracking()
                .ToListAsync();

            return allRecepies;
            }

        public async Task AddPostAsync(FoodViewModel model, string userId, List<Step> addSteps, List<Ingredient> addIngredients)
            {
            var newRecepie = new FoodRecepie()
                {
                Name = model.Name,
                Description = model.Description,
                DatePosted = DateTime.Now,
                Image = model.Image,
                PrepTime = model.PrepTime,
                CookTime = model.CookTime,
                Portions = model.Portions,
                OvenTypeId = model.OvenTypeId,
                RecepieTypeId = model.RecepieTypeId,
                Origen = model.Origen,
                Temperature = model.Temperature,
                TemperatureMeasurmentId = model.TemperatureTypeId,
                OwnerId = userId,
                TumbsUp = 0,
                IsPrivate = model.IsPrivate,
                };


            foreach (var step in addSteps)
                {
                var stepRecepie = new FoodStepsFoodRecepies()
                    {
                    FoodRecepie = newRecepie,
                    FoodStep = step,
                    };
                await repository.AddAsync(step);
                await repository.AddAsync(stepRecepie);

                }

            foreach (var ing in addIngredients)
                {
                var ingFoodRec = new IngredientFoodRecepie
                    {
                    Ingredient = ing,
                    Recepie = newRecepie
                    };
                await repository.AddAsync(ing);
                await repository.AddAsync(ingFoodRec);
                }

            await repository.AddAsync(newRecepie);

            try
                {
                await repository.SaveChangesAsync();
                }
            catch (Exception ex)
                {
                await Console.Out.WriteLineAsync(ex.Message);
                if (ex.InnerException != null)
                    {
                    await Console.Out.WriteLineAsync(ex.GetCompleteMessage());
                    }
                }
            }
        public async Task<EditFoodForm> EditGetAsync(int id, string userId)
            {
            var recepie = await repository
                .AllReadOnly<FoodRecepie>()
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = new EditFoodForm()
                {
                Id = recepie.Id,
                Name = recepie.Name,
                Description = recepie.Description,
                RecepieTypeId = recepie.Id,
                RecepieTypes = await GetRecepieTypeAsync(),
                Image = recepie.Image,
                PrepTime = recepie.PrepTime,
                CookTime = recepie.CookTime,
                Temperature = recepie.Temperature,
                TemperatureTypeId = recepie.TemperatureMeasurmentId,
                TemperatureTypes = await GetTemperatureTypeAsync(),
                OvenTypeId = recepie.OvenTypeId,
                OvenTypes = await GetOvenTypeAsync(),
                MeasurmentId = recepie.TemperatureMeasurmentId,
                MeasurmentTypes = await GetMeasurmentTypeAsync(),
                IsPrivate = recepie.IsPrivate,
                Origen = recepie.Origen,
                Portions = recepie.Portions,
                };

            return result;
            }

        public async Task<int> EditPostAsync(EditFoodForm model)
            {
            var recepie = await repository
                .GetByIdAsync<FoodRecepie>(model.Id);

            if (recepie != null)
                {
                recepie.Name = model.Name;
                recepie.Description = model.Description;
                recepie.Image = model.Image;
                recepie.PrepTime = model.PrepTime;
                recepie.CookTime = model.CookTime;
                recepie.Portions = model.Portions;
                recepie.OvenTypeId = model.OvenTypeId;
                recepie.RecepieTypeId = model.RecepieTypeId;
                recepie.IsPrivate = model.IsPrivate;
                recepie.Origen = model.Origen;
                recepie.Temperature = model.Temperature;
                recepie.TemperatureMeasurmentId = model.TemperatureTypeId;

                await repository.SaveChangesAsync();
                }

            return model.Id;
            }

        public async Task<DetailedFoodViewModel> DetailGetAsync(int id, string userId)
            {
            var recepie = await repository
                .All<FoodRecepie>()
                .Where(x => x.Id == id)
                .Select(x => new DetailedFoodViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    RecepieType = x.RecepieType.Name,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    PrepTime = x.PrepTime,
                    CookTime = x.CookTime,
                    Temperature = x.Temperature,
                    TemperatureType = x.TemperatureMeasurment.Name,
                    OvenType = x.OvenType.Name,
                    Origen = x.Origen,
                    TumbsUp = x.TumbsUp,
                    Portions = x.Portions,
                    Owner = x.Owner.UserName,
                    })
                .FirstOrDefaultAsync();

            var ing = await repository
                .All<IngredientFoodRecepie>()
                .Where(x => x.RecepieId == recepie.Id)
                .Select(x => new Ingredient()
                    {
                    Id = x.IngredientId,
                    Amount = x.Ingredient.Amount,
                    Name = x.Ingredient.Name,
                    Measurement = x.Ingredient.Measurement,
                    })
                .ToListAsync();

            var steps = await repository
                .All<FoodStepsFoodRecepies>()
                .Where(x => x.FoodRecepieId == recepie.Id)
                .Select(x => new Step()
                    {
                    Id = x.FoodStep.Id,
                    Description = x.FoodStep.Description,
                    Position = x.FoodStep.Position,
                    })
                .OrderBy(x => x.Position)
                .ToListAsync();

            recepie = await GetLIkesAndFavorites(recepie, userId);

            recepie.Ingredients = ing;
            recepie.Steps = steps;

            return recepie;
            }

        public async Task<DetailedFoodViewModel> DeleteAsync(int id, string userId)
            {
            var recepie = await repository
                .All<FoodRecepie>()
                .Where(x => x.Id == id)
                .Select(x => new DetailedFoodViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    RecepieType = x.RecepieType.Name,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    PrepTime = x.PrepTime,
                    CookTime = x.CookTime,
                    Temperature = x.Temperature,
                    TemperatureType = x.TemperatureMeasurment.Name,
                    OvenType = x.OvenType.Name,
                    Origen = x.Origen,
                    TumbsUp = x.TumbsUp,
                    Portions = x.Portions,
                    Owner = x.Owner.UserName,
                    OwnerId = x.OwnerId,
                    })
                .FirstOrDefaultAsync();

            var ing = await repository
                .AllReadOnly<IngredientFoodRecepie>()
                .Where(x => x.RecepieId == recepie.Id)
                .Select(x => new Ingredient()
                    {
                    Id = x.IngredientId,
                    Amount = x.Ingredient.Amount,
                    Name = x.Ingredient.Name,
                    })
                .ToListAsync();

            var steps = await repository
                .AllReadOnly<FoodStepsFoodRecepies>()
                .Where(x => x.FoodRecepieId == recepie.Id)
                .Select(x => new Step()
                    {
                    Id = x.FoodStep.Id,
                    Description = x.FoodStep.Description,
                    Position = x.FoodStep.Position,
                    })
                .OrderBy(x => x.Position)
                .ToListAsync();

            recepie.Ingredients = ing;
            recepie.Steps = steps;

            return recepie;
            }

        public async Task ConfirmDeleteAsync(int id)
            {
            var allLikes = repository
                .AllReadOnly<FoodLikeUser>()
                .Where(x => x.FoodRecepieId == id);
            foreach (var like in allLikes)
                {
                await repository.DeleteElementAsync(like);
                }
            var allFavourites = repository
                .AllReadOnly<FavouriteFoodRecepiesUsers>()
                .Where(x => x.FoodRecepieId == id);

            await repository.DeleteAsync<FoodRecepie>(id);
            await repository.SaveChangesAsync();
            }

        public async Task<EditIngredientsForm> EditIngredientGetAsync(int id)
            {
            var recepie = await repository
                .All<IngredientFoodRecepie>()
                .Where(x => x.IngredientId == id)
                .Select(x => new EditIngredientsForm()
                    {
                    Id = x.IngredientId,
                    Name = x.Ingredient.Name,
                    Description = x.Ingredient.Description,
                    Amount = x.Ingredient.Amount,
                    MeasurmentId = x.Ingredient.MeasurementId,
                    OwnerId = x.Recepie.OwnerId
                    })
                .FirstOrDefaultAsync();

            recepie.MeasurmentTypes = await GetMeasurmentTypeAsync();

            return recepie;
            }

        public async Task<EditIngredientsForm> EditIngredientPostAsync(EditIngredientsForm model)
            {
            var ing = await repository
                .GetByIdAsync<Ingredient>(model.Id);


            ing.MeasurementId = model.MeasurmentId;
            ing.Name = model.Name;
            ing.Amount = model.Amount;
            ing.Description = model.Description;

            await repository.SaveChangesAsync();

            var recepie = repository
                .AllReadOnly<FoodRecepie>()
                .Where(r =>
                    r.IngredientsRecepies
                    .Any(x => x.IngredientId == model.Id))
                .First();
            return new EditIngredientsForm()
                {
                Id = recepie.Id,
                OwnerId = recepie.OwnerId,
                };
            }

        public async Task<EditStepForm> EditStepGetAsync(int id)
            {
            var recepie = await repository
                .All<FoodStepsFoodRecepies>()
                .Where(x => x.FoodStepId == id)
                .Select(x => new EditStepForm()
                    {
                    Id = x.FoodStepId,
                    Description = x.FoodStep.Description,
                    OwnerId = x.FoodRecepie.OwnerId
                    })
                .FirstOrDefaultAsync();

            return recepie;
            }

        public async Task<EditStepForm> EditStepPostAsync(EditStepForm model)
            {
            var ing = await repository
                .All<Step>()
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            ing.Description = model.Description;

            await repository.SaveChangesAsync();

            var recepie = repository
                .AllReadOnly<FoodRecepie>()
                .Where(r =>
                    r.Steps
                    .Any(x => x.FoodStepId == model.Id))
                .First();

            return new EditStepForm()
                {
                Id = recepie.Id,
                OwnerId = recepie.OwnerId,
                }; ;
            }


        }
    }
