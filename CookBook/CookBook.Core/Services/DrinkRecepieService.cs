using CookBook.Core.Contracts.Services;
using CookBook.Core.Enum;
using CookBook.Core.Models.Drink;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Core.Utilities;
using CookBook.Infrastructures.Data.Common;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Core.Services
    {
    public class DrinkRecepieService : IDrinkRecepieService
        {
        private readonly IRepository repository;

        public DrinkRecepieService(IRepository repository)
            {
            this.repository = repository;
            }

        /// <summary>
        /// Veryfication and Authorisation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<bool> Authorised(int id, string userId)
            {
            return await repository
                 .AllReadOnly<DrinkRecepie>()
                 .Where(r => r.Id == id)
                 .AllAsync(x => x.OwnerId == userId);
            }

        public async Task<bool> Exist(int id)
            {
            return await repository
                .AllReadOnly<DrinkRecepie>()
                .AnyAsync(r => r.Id == id);
            }

        public async Task<bool> AuthorisedStep(int id, string userId)
            {
            return await repository
                 .AllReadOnly<DrinkRecepie>()
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
                 .AllReadOnly<DrinkRecepie>()
                 .Where(r => r.Steps.Any(i => i.StepId == id))
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

        public IEnumerable<AllRecepieViewModel> GetLIkesAndFavoritesMany(List<AllRecepieViewModel> allRecepies, string userId)
            {

            var likes = repository
                .AllReadOnly<DrinkLikeUser>()
                .Where(x => x.UserId == userId)
                .ToList();

            foreach (var i in likes)
                {
                allRecepies.First(x => x.Id == i.DrinkRecepieId)
                    .Like = true;
                }

            var favourite = repository
                .AllReadOnly<FavouriteDrinkRecepiesUsers>()
                .Where(x => x.UserId == userId)
                .ToList();

            foreach (var i in favourite)
                {
                allRecepies.First(x => x.Id == i.DrinkRecepieId)
                    .Favourite = true;
                }

            return allRecepies;
            }

        public async Task<DetailedDrinkViewModel> GetLIkesAndFavorites(DetailedDrinkViewModel recepie, string userId)
            {

            var likes = await repository
                .AllReadOnly<DrinkLikeUser>()
                .Where(x => x.UserId == userId && x.DrinkRecepieId == recepie.Id)
                .FirstOrDefaultAsync();

            if (likes != null)
                {
                recepie.Like = true;
                }

            var favourite = repository
                .AllReadOnly<FavouriteDrinkRecepiesUsers>()
                .Where(x => x.UserId == userId && x.DrinkRecepieId == recepie.Id)
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
        public async Task<DrinkViewModel> AddGetAsync()
            {
            return new DrinkViewModel()
                {
                MeasurmentTypes = await GetMeasurmentTypeAsync(),
                };
            }

        public async Task<AllRecepieQuerySerciveModel> AllAsync(AllRecepieQuerySerciveModel query, string userId)
            {
            var targetRec = await repository
                .AllReadOnly<DrinkRecepie>()
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
            query.TotalRecepiesCount = targetRec.Count;

            return query;
            }

        public async Task<IEnumerable<AllRecepieViewModel>> PrivateAsync(string userId)
            {
            return await repository
                .AllReadOnly<DrinkRecepie>()
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
            }

        public async Task AddPostAsync(DrinkViewModel model, string userId, List<Step> addSteps, List<Ingredient> addIngredients)
            {
            var newRecepie = new DrinkRecepie()
                {
                Name = model.Name,
                Description = model.Description,
                DatePosted = DateTime.Now,
                Image = model.Image,
                Origen = model.Origen,
                OwnerId = userId,
                TumbsUp = 0,
                IsPrivate = model.IsPrivate,
                };


            foreach (var step in addSteps)
                {
                var stepRecepie = new DrinkStepsDrinkRecepies()
                    {
                    DrinkRecepie = newRecepie,
                    DrinkStep = step,
                    };
                await repository.AddAsync(step);
                await repository.AddAsync(stepRecepie);

                }

            foreach (var ing in addIngredients)
                {
                var ingDrinkRec = new IngredientDrinkRecepie
                    {
                    Ingredient = ing,
                    Recepie = newRecepie
                    };
                await repository.AddAsync(ing);
                await repository.AddAsync(ingDrinkRec);
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
        public async Task<EditDrinkForm> EditGetAsync(int id, string userId)
            {
            var recepie = await repository
                .AllReadOnly<DrinkRecepie>()
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = new EditDrinkForm()
                {
                Id = recepie.Id,
                Name = recepie.Name,
                Description = recepie.Description,
                Image = recepie.Image,
                MeasurmentTypes = await GetMeasurmentTypeAsync(),
                IsPrivate = recepie.IsPrivate,
                Origen = recepie.Origen,
                Cups = recepie.Cups,
                };

            return result;
            }

        public async Task<int> EditPostAsync(EditDrinkForm model)
            {
            var recepie = await repository
                .GetByIdAsync<DrinkRecepie>(model.Id);

            if (recepie != null)
                {
                recepie.Name = model.Name;
                recepie.Description = model.Description;
                recepie.Image = model.Image;
                recepie.IsPrivate = model.IsPrivate;
                recepie.Origen = model.Origen;

                await repository.SaveChangesAsync();
                }

            return model.Id;
            }

        public async Task<DetailedDrinkViewModel> DetailGetAsync(int id, string userId)
            {
            var recepie = await repository
                .All<DrinkRecepie>()
                .Where(x => x.Id == id)
                .Select(x => new DetailedDrinkViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    Origen = x.Origen,
                    TumbsUp = x.TumbsUp,
                    Cups = x.Cups,
                    Owner = x.Owner.UserName,
                    })
                .FirstOrDefaultAsync();

            var ing = await repository
                .All<IngredientDrinkRecepie>()
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
                .All<DrinkStepsDrinkRecepies>()
                .Where(x => x.DrinkRecepieId == recepie.Id)
                .Select(x => new Step()
                    {
                    Id = x.DrinkStep.Id,
                    Description = x.DrinkStep.Description,
                    Position = x.DrinkStep.Position,
                    })
                .OrderBy(x => x.Position)
                .ToListAsync();

            recepie = await GetLIkesAndFavorites(recepie, userId);

            recepie.Ingredients = ing;
            recepie.Steps = steps;

            return recepie;
            }

        public async Task<DetailedDrinkViewModel> DeleteAsync(int id, string userId)
            {
            var recepie = await repository
                .All<DrinkRecepie>()
                .Where(x => x.Id == id)
                .Select(x => new DetailedDrinkViewModel()
                    {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    DatePosted = x.DatePosted,
                    Image = x.Image,
                    Origen = x.Origen,
                    TumbsUp = x.TumbsUp,
                    Cups = x.Cups,
                    Owner = x.Owner.UserName,
                    OwnerId = x.OwnerId,
                    })
                .FirstOrDefaultAsync();

            var ing = await repository
                .AllReadOnly<IngredientDrinkRecepie>()
                .Where(x => x.RecepieId == recepie.Id)
                .Select(x => new Ingredient()
                    {
                    Id = x.IngredientId,
                    Amount = x.Ingredient.Amount,
                    Name = x.Ingredient.Name,
                    })
                .ToListAsync();

            var steps = await repository
                .AllReadOnly<DrinkStepsDrinkRecepies>()
                .Where(x => x.DrinkRecepieId == recepie.Id)
                .Select(x => new Step()
                    {
                    Id = x.DrinkStep.Id,
                    Description = x.DrinkStep.Description,
                    Position = x.DrinkStep.Position,
                    })
                .OrderBy(x => x.Position)
                .ToListAsync();

            recepie.Ingredients = ing;
            recepie.Steps = steps;

            return recepie;
            }

        public async Task ConfirmDeleteAsync(int id)
            {
            await repository.DeleteAsync<DrinkRecepie>(id);
            await repository.SaveChangesAsync();
            }

        public async Task<EditIngredientsForm> EditIngredientGetAsync(int id)
            {
            var recepie = await repository
                .All<IngredientDrinkRecepie>()
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
                .AllReadOnly<DrinkRecepie>()
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
                .All<DrinkStepsDrinkRecepies>()
                .Where(x => x.StepId == id)
                .Select(x => new EditStepForm()
                    {
                    Id = x.StepId,
                    Description = x.DrinkStep.Description,
                    OwnerId = x.DrinkRecepie.OwnerId
                    })
                .FirstAsync();

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
                .AllReadOnly<DrinkRecepie>()
                .Where(r =>
                    r.Steps
                    .Any(x => x.StepId == model.Id))
                .First();

            return new EditStepForm()
                {
                Id = recepie.Id,
                OwnerId = recepie.OwnerId,
                }; ;
            }


        }
    }
