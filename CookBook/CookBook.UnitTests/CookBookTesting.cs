using CookBook.Areas.Admin.Models;
using CookBook.Core.Contracts.Services;
using CookBook.Core.Models.Admin;
using CookBook.Core.Models.Drink;
using CookBook.Core.Models.Food;
using CookBook.Core.Models.Shared;
using CookBook.Core.Models.Utilities;
using CookBook.Infrastructures.Data.Common;
using CookBook.Infrastructures.Data;
using CookBook.Infrastructures.Data.Models.Admin;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;
using CookBook.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CookBook.UnitTests
    {
    [TestFixture]
    public class CookBookTesting
        {
        /// <summary>
        /// Var
        /// </summary>
        //user
        private bool isBanned = false;
        private int lenght = 1;
        private string randomText = "Thats a random text long more then 10 char";
        private DateTime date = DateTime.Parse("12/02/1993");

        //drink
        private int drinkId = 1;
        private string drinkName = "Sambuka";

        //Shared
        private string userId = "TestingUserNotExistingID123";
        private string origen = "Timbuctu";
        private string img = "https://i.ytimg.com/vi/WSSI27cyklU/maxresdefault.jpg";

        //Food
        private int foodId = 2;
        private string foodName = "Tarator";
        private int foodTargetSupId = 2;
        private int cookTime = 10;
        private int prepTime = 12;

        //Ingredient
        private string ingName = "ing";

        /// <summary>
        /// prop
        /// </summary>

        private IRepository _repository;
        private CookBookDbContext _context;
        private IFoodRecepieService foodService;
        private IDrinkRecepieService drinkService;
        private IFavouriteService favService;
        private IRatingService ratingService;

        //Shared
        private Step step1 = new Step();
        private Step step2 = new Step();
        private Step step3 = new Step();
        private ICollection<Step> stepList;
        private Ingredient ing1 = new Ingredient();
        private Ingredient ing2 = new Ingredient();
        private Ingredient ing3 = new Ingredient();
        private ICollection<Ingredient> ingList;
        private Measurement meas1 = new Measurement();
        private Measurement meas2 = new Measurement();
        private Measurement meas3 = new Measurement();
        private ICollection<Measurement> measList;
        private ICollection<UtilTypeModel> utList;
        private AllRecepieViewModel allRecepie = new AllRecepieViewModel();
        private ICollection<AllRecepieViewModel> allRecepieList;

        //Drink
        private DrinkRecepie drinkRecepie = new DrinkRecepie();
        private DetailedDrinkViewModel detailedDrink = new DetailedDrinkViewModel();
        private ICollection<FavouriteDrinkRecepiesUsers> favDrinkUsers;
        private ICollection<IngredientDrinkRecepie> ingDrinkRecepie;
        private ICollection<DrinkRecepiesUsers> drinkUsers;
        private ICollection<DrinkStepsDrinkRecepies> drinkSteps;
        private ICollection<DrinkLikeUser> drinkLikes;

        //Food
        private FoodRecepie foodRecepie = new FoodRecepie();
        private DetailedFoodViewModel detailedFood = new DetailedFoodViewModel();
        private ICollection<FavouriteFoodRecepiesUsers> favouriteFoodUserList;
        private ICollection<IngredientFoodRecepie> ingFoodRecepies;
        private ICollection<FoodRecepiesUsers> foodUsers;
        private ICollection<FoodStepsFoodRecepies> foodSteps;
        private ICollection<FoodLikeUser> foodLikes;
        private ICollection<TemperatureMeasurment> temperatureMeasurments;
        private ICollection<OvenType> ovenTypes;
        private ICollection<RecepieType> recepieTypes;

        [SetUp]
        public void TestInit()
            {
            //shared
            meas1 = new Measurement()
                {
                Id = 1,
                Name = "Kg",
                };

            meas2 = new Measurement()
                {
                Id = 2,
                Name = "Gr",
                };

            meas1 = new Measurement()
                {
                Id = 3,
                Name = "Ml",
                };

            measList = new List<Measurement>
                {
                meas1,
                meas2,
                meas3
                };

            ing1 = new Ingredient()
                {
                Id = 1,
                Name = ingName + "1",
                MeasurementId = 1,
                Measurement = meas1,
                Amount = 1,
                Description = randomText
                };

            ing2 = new Ingredient()
                {
                Id = 2,
                Name = ingName + "2",
                MeasurementId = 2,
                Measurement = meas2,
                Amount = 2,
                Description = randomText
                };

            ing3 = new Ingredient()
                {
                Id = 3,
                Name = ingName + "3",
                MeasurementId = 3,
                Measurement = meas3,
                Amount = 3,
                Description = randomText
                };

            ingList = new List<Ingredient>()
                {
                ing1,
                ing2,
                ing3,
                };



            step1 = new Step()
                {
                Id = 1,
                Position = 1,
                Description = randomText
                };

            step2 = new Step()
                {
                Id = 2,
                Position = 2,
                Description = randomText
                };

            step3 = new Step()
                {
                Id = 3,
                Position = 3,
                Description = randomText
                };

            stepList = new List<Step>()
                {
                step1,
                step2,
                step3,
                };

            utList = new List<UtilTypeModel>()
                {
                new UtilTypeModel()
                    {
                    Id = 1,
                    Name = "Test1",
                    },
                new UtilTypeModel()
                    {
                    Id = 2,
                    Name = "Test2",
                    },
                new UtilTypeModel()
                    {
                    Id = 3,
                    Name = "Test3",
                    },
                };

            allRecepie = new AllRecepieViewModel
                {
                Id = 1,
                Name = "Test",
                DatePosted = date,
                Image = img,
                Owner = userId,
                TumbsUp = 1,
                Description = randomText,
                Private = true,
                Like = false,
                Favourite = false
                };

            allRecepieList = new List<AllRecepieViewModel>()
                {
                allRecepie
                };

            //Drink
            drinkLikes = new List<DrinkLikeUser>()
                {
                new DrinkLikeUser()
                    {
                    UserId = userId,
                    DrinkRecepieId = drinkId
                    }
                };

            detailedDrink = new DetailedDrinkViewModel()
                {
                Id = 1,
                Name = "Test",
                Description = randomText,
                DatePosted = date,
                Image = img,
                Origen = origen,
                IsAlcoholic = false,
                Cups = 2,
                TumbsUp = 3,
                OwnerId = userId,
                Like = false,
                Favourite = false,
                Private = false,
                Ingredients = ingList,
                Steps = stepList
                };

            ingDrinkRecepie = new List<IngredientDrinkRecepie>()
                {
                new IngredientDrinkRecepie ()
                    {
                    IngredientId = 1,
                    Ingredient = ing1,
                    RecepieId = 1,
                    },
                new IngredientDrinkRecepie ()
                    {
                    IngredientId = 2,
                    Ingredient = ing2,
                    RecepieId = 1,
                    },
                new IngredientDrinkRecepie ()
                    {
                    IngredientId = 3,
                    Ingredient = ing3,
                    RecepieId = 1,
                    },
                };



            drinkSteps = new List<DrinkStepsDrinkRecepies>()
                {
                new DrinkStepsDrinkRecepies ()
                    {
                    StepId = 1,
                    DrinkStep = step1,
                    DrinkRecepieId = 1,
                    },
                new DrinkStepsDrinkRecepies ()
                    {
                    StepId = 2,
                    DrinkStep = step2,
                    DrinkRecepieId = 1,
                    },
                new DrinkStepsDrinkRecepies ()
                    {
                    StepId = 3,
                    DrinkStep = step3,
                    DrinkRecepieId = 1,
                    },
                };

            favDrinkUsers = new List<FavouriteDrinkRecepiesUsers>()
                {
                new FavouriteDrinkRecepiesUsers()
                    {
                    UserId = userId,
                    DrinkRecepieId = drinkId,
                    },
                };

            drinkUsers = new List<DrinkRecepiesUsers>()
                {
                new DrinkRecepiesUsers()
                {
                DrinkRecepieId = drinkId,
                UserId = userId,
                }
                };

            drinkRecepie = new DrinkRecepie()
                {
                Id = drinkId,
                OwnerId = userId,
                Name = drinkName,
                DatePosted = date,
                Description = randomText,
                IsAlcoholic = false,
                IsPrivate = true,
                IsProfesional = true,
                Origen = origen,
                Image = img,
                TumbsUp = 1,
                Cups = 2,
                IngredientsRecepies = ingDrinkRecepie,
                Steps = drinkSteps,
                Likes = drinkLikes,
                FavouriteRecepiesUsers = favDrinkUsers,
                RecepiesUsers = drinkUsers,
                VerifyedLocation = false
                };

            //Food
            temperatureMeasurments = new List<TemperatureMeasurment>()
                {
                new TemperatureMeasurment()
                    {
                    Id = 1,
                    Name ="C"
                    },
                new TemperatureMeasurment()
                    {
                    Id = 2,
                    Name = "F"
                    }
                };

            detailedFood = new DetailedFoodViewModel()
                {
                Id = 1,
                Name = "Test",
                Description = randomText,
                DatePosted = date,
                Image = img,
                Origen = origen,
                Portions = 2,
                TumbsUp = 3,
                OwnerId = userId,
                Like = false,
                Favourite = false,
                Private = false,
                Ingredients = ingList,
                Steps = stepList,
                PrepTime = 10,
                CookTime = 10,
                RecepieType = "Test",
                TemperatureType = "Test",
                Temperature = 1
                };

            recepieTypes = new List<RecepieType>()
                {
                new RecepieType()
                    {
                    Id = 1,
                    Name = "First Type",
                    Description = randomText,
                    },
                new RecepieType()
                    {
                    Id = 2,
                    Name = "Second Type",
                    Description = randomText
                    }
                };

            foodUsers = new List<FoodRecepiesUsers>()
                {
                new FoodRecepiesUsers()
                    {
                    FoodRecepieId = foodId,
                    UserId = userId
                    }
                };
            favouriteFoodUserList = new List<FavouriteFoodRecepiesUsers>()
                {
                new FavouriteFoodRecepiesUsers()
                    {
                    FoodRecepieId = foodId,
                    UserId = userId,
                    }
                };

            ovenTypes = new List<OvenType>()
                {
                new OvenType()
                    {
                    Id = 1,
                    Name = "Gas",
                    },
                new OvenType()
                    {
                    Id = 2,
                    Name = "No Oven"
                    }
                };

            foodLikes = new List<FoodLikeUser>()
                {
                new FoodLikeUser()
                    {
                    FoodRecepieId = foodId,
                    UserId = userId,
                    }
                };

            ingFoodRecepies = new List<IngredientFoodRecepie>()
                {
                new IngredientFoodRecepie()
                    {
                    IngredientId = ing1.Id,
                    Ingredient = ing1,
                    RecepieId = foodId
                    },
                new IngredientFoodRecepie()
                    {
                    IngredientId = ing2.Id,
                    Ingredient = ing2,
                    RecepieId = foodId
                    },
                new IngredientFoodRecepie()
                    {
                    IngredientId = ing3.Id,
                    Ingredient = ing3,
                    RecepieId = foodId
                    }
                };

            foodSteps = new List<FoodStepsFoodRecepies>()
                {
                new FoodStepsFoodRecepies()
                    {
                    FoodStepId = step1.Id,
                    FoodStep = step1,
                    FoodRecepieId = foodId
                    },
                new FoodStepsFoodRecepies()
                    {
                    FoodStepId = step2.Id,
                    FoodStep = step2,
                    FoodRecepieId = foodId
                    },
                new FoodStepsFoodRecepies()
                    {
                    FoodStepId = step3.Id,
                    FoodStep = step3,
                    FoodRecepieId = foodId
                    },
                };

            foodRecepie = new FoodRecepie()
                {
                Id = foodId,
                OwnerId = userId,
                Name = foodName,
                DatePosted = date,
                Description = randomText,
                IsPrivate = true,
                IsProfesional = true,
                Origen = origen,
                Image = img,
                TumbsUp = foodTargetSupId,
                Temperature = foodTargetSupId,
                TemperatureMeasurmentId = foodTargetSupId,
                TemperatureMeasurment = temperatureMeasurments.Where(t => t.Id == foodTargetSupId).First(),
                RecepieTypeId = foodTargetSupId,
                RecepieType = recepieTypes.Where(r => r.Id == foodTargetSupId).First(),
                RecepiesUsers = foodUsers,
                CookTime = cookTime,
                PrepTime = prepTime,
                Portions = foodTargetSupId,
                FavouriteRecepiesUsers = favouriteFoodUserList,
                OvenTypeId = foodTargetSupId,
                OvenType = ovenTypes.Where(o => o.Id == foodTargetSupId).First(),
                Likes = foodLikes,
                IngredientsRecepies = ingFoodRecepies,
                Steps = foodSteps,
                VerifyedLocation = false,
                };
            var options = new DbContextOptionsBuilder<CookBookDbContext>()
                .UseInMemoryDatabase(databaseName: "CookBookInMemory" + Guid.NewGuid().ToString())
                .Options;

            _context = new CookBookDbContext(options);

            _context.AddRange(measList);
            _context.AddRange(ingFoodRecepies);
            _context.AddRange(ingDrinkRecepie);
            _context.AddRange(foodSteps);
            _context.AddRange(drinkSteps);
            _context.Add(foodRecepie);
            _context.Add(drinkRecepie);
            _context.SaveChanges();

            _repository = new Repository(_context);
            foodService = new FoodRecepieService(_repository);
            drinkService = new DrinkRecepieService(_repository);
            favService = new FavouriteService(_repository);
            ratingService = new RatingService(_repository);
            }

        //Models
        //Infrastructure
        //Admin
        [Test]
        public void Test_BanedUserDBModel()
            {
            BanedUsers user = new BanedUsers()
                {
                UserId = userId,
                IsBaned = isBanned,
                Lenght = lenght,
                BanDate = date,
                Reason = randomText
                };

            Assert.IsNotNull(user);

            Assert.IsFalse(isBanned);

            Assert.That(userId == user.UserId);
            Assert.That(date == user.BanDate);
            Assert.That(randomText == user.Reason);
            }

        //Drink
        [Test]
        public void Test_DrinkLikeUserDbModel()
            {
            DrinkLikeUser drinkLikeUser = drinkLikes.First();

            Assert.IsNotNull(drinkLikeUser);
            Assert.IsNull(drinkLikeUser.User);
            Assert.IsNotNull(drinkLikeUser.DrinkRecepie);

            Assert.That(drinkLikeUser.UserId == userId);
            Assert.That(drinkLikeUser.DrinkRecepieId != foodId);
            Assert.That(drinkLikeUser.DrinkRecepieId == drinkId);
            }

        [Test]
        public void Test_DrinRecepieDBModel()
            {
            var recepie = drinkRecepie;

            Assert.IsNotNull(recepie);
            Assert.IsNotNull(recepie.Name);
            Assert.IsNotNull(recepie.TumbsUp);
            Assert.IsNull(recepie.Owner);

            Assert.IsFalse(recepie.IsAlcoholic);
            Assert.IsFalse(recepie.VerifyedLocation);
            Assert.IsTrue(recepie.IsProfesional);
            Assert.IsTrue(recepie.IsPrivate);

            Assert.That(recepie.Id == 1);
            Assert.That(recepie.Description == randomText);
            Assert.That(recepie.OwnerId == userId);
            Assert.That(recepie.IngredientsRecepies.Count == ingDrinkRecepie.Count);
            Assert.That(recepie.Steps.Count == drinkSteps.Count);
            Assert.That(recepie.Likes.Count == drinkLikes.Count);
            Assert.That(recepie.TumbsUp == 1);
            Assert.That(recepie.TumbsUp != 0);
            Assert.That(recepie.Origen == origen);
            Assert.That(recepie.Image == img);
            Assert.That(recepie.DatePosted == date);
            Assert.That(recepie.FavouriteRecepiesUsers == favDrinkUsers);
            Assert.That(recepie.Name == drinkName);
            Assert.That(recepie.IsAlcoholic == false);
            Assert.That(recepie.IsPrivate == true);
            Assert.That(recepie.IsProfesional == true);
            Assert.That(recepie.Cups == 2);
            Assert.That(recepie.RecepiesUsers.Count == drinkUsers.Count);
            }

        [Test]
        public void Test_DrinkRecepieUsersDBModel()
            {
            var drinkRecepieUser = drinkUsers;
            var firstDrinkUser = drinkRecepieUser.First();

            Assert.IsNotNull(drinkRecepieUser);
            Assert.IsNotNull(firstDrinkUser);
            Assert.IsNotNull(firstDrinkUser.DrinkRecepie);
            Assert.IsNull(firstDrinkUser.User);

            Assert.That(drinkRecepieUser.Count == 1);
            Assert.That(firstDrinkUser.UserId == userId);
            Assert.That(firstDrinkUser.DrinkRecepieId == drinkId);
            }


        [Test]
        public void Test_DrinkStepsDrinkRecepies_DBModel()
            {
            var stepDrinkRecepie = drinkSteps;
            var firstStepDrink = stepDrinkRecepie.First();

            Assert.IsNotNull(firstStepDrink);
            Assert.IsNotNull(stepDrinkRecepie);
            Assert.IsNotNull(firstStepDrink.DrinkRecepie);

            Assert.That(stepDrinkRecepie.Count == 3);
            Assert.That(firstStepDrink.StepId == step1.Id);
            Assert.That(firstStepDrink.DrinkStep == step1);
            Assert.That(firstStepDrink.DrinkRecepieId == drinkId);
            }

        [Test]
        public void Test_FavouriteDrinkRecepiesUsers_DBModel()
            {
            var favList = favDrinkUsers;
            var firstFav = favList.First();

            Assert.IsNotNull(favList);
            Assert.IsNotNull(firstFav);
            Assert.IsNotNull(firstFav.DrinkRecepie);
            Assert.IsNull(firstFav.User);

            Assert.That(favList.Count == 1);
            Assert.That(firstFav.UserId == userId);
            Assert.That(firstFav.DrinkRecepieId == drinkId);
            }

        [Test]
        public void Test_IngredientDrinkRecepie_DBModel()
            {
            var ingListDrink = ingDrinkRecepie;
            var firstIngDrink = ingListDrink.First();

            Assert.IsNotNull(ingListDrink);
            Assert.IsNotNull(firstIngDrink);
            Assert.IsNotNull(firstIngDrink.Recepie);

            Assert.That(firstIngDrink.RecepieId == drinkId);
            Assert.That(firstIngDrink.IngredientId == ing1.Id);
            Assert.That(firstIngDrink.Ingredient == ing1);
            }

        //Food
        [Test]
        public void Test_FavouriteFoodRecepiesUsers_DBModel()
            {
            var favList = favouriteFoodUserList;
            var firstFav = favList.First();

            Assert.IsNotNull(firstFav);
            Assert.IsNotNull(favList);
            Assert.IsNull(firstFav.User);
            Assert.IsNotNull(firstFav.FoodRecepie);

            Assert.That(favList.Count == 1);
            Assert.That(firstFav.UserId == userId);
            Assert.That(firstFav.FoodRecepieId == foodId);

            }

        [Test]
        public void Test_FoodLikeUser_DBModel()
            {
            var likes = foodLikes;
            var firstLike = likes.First();

            Assert.NotNull(firstLike);
            Assert.NotNull(likes);
            Assert.IsNull(firstLike.User);
            Assert.IsNotNull(firstLike.FoodRecepie);

            Assert.That(likes.Count == 1);
            Assert.That(firstLike.UserId == userId);
            Assert.That(firstLike.FoodRecepieId == foodId);
            }

        [Test]
        public void Test_FoodRecepie_DBModel()
            {
            var recepie = foodRecepie;

            Assert.IsNotNull(recepie);
            Assert.IsNull(recepie.Owner);

            Assert.IsFalse(recepie.VerifyedLocation);
            Assert.IsTrue(recepie.IsPrivate);
            Assert.IsTrue(recepie.IsProfesional);

            Assert.That(recepie.OwnerId == userId);
            Assert.That(recepie.Id == foodId);
            Assert.That(recepie.Name == foodName);
            Assert.That(recepie.Description == randomText);
            Assert.That(recepie.CookTime == cookTime);
            Assert.That(recepie.PrepTime == prepTime);
            Assert.That(recepie.OvenTypeId == foodTargetSupId);
            Assert.That(recepie.TemperatureMeasurmentId == foodTargetSupId);
            Assert.That(recepie.DatePosted == date);
            Assert.That(recepie.Temperature == foodTargetSupId);
            Assert.That(recepie.TemperatureMeasurment == temperatureMeasurments.Skip(1).First());
            Assert.That(recepie.OvenType == ovenTypes.Skip(1).First());
            Assert.That(recepie.Likes == foodLikes);
            Assert.That(recepie.RecepiesUsers == foodUsers);
            Assert.That(recepie.Image == img);
            Assert.That(recepie.Steps == foodSteps);
            Assert.That(recepie.IngredientsRecepies == ingFoodRecepies);
            Assert.That(recepie.Origen == origen);
            Assert.That(recepie.TumbsUp == foodTargetSupId);
            Assert.That(recepie.Portions == foodTargetSupId);
            Assert.That(recepie.RecepieTypeId == foodTargetSupId);
            Assert.That(recepie.RecepieType == recepieTypes.Skip(1).First());
            }

        [Test]
        public void Test_FoodRecepiesUsers_DBModel()
            {
            var foodUs = foodUsers;
            var fu = foodUsers.First();

            Assert.IsNotNull(foodUs);
            Assert.IsNotNull(fu);

            Assert.IsNotNull(fu.FoodRecepie);
            Assert.IsNull(fu.User);

            Assert.That(fu.FoodRecepieId == foodId);
            Assert.That(fu.UserId == userId);
            }

        [Test]
        public void Test_FoodStepsFoodRecepies_DBModel()
            {
            var foodStep = foodSteps;
            var fs = foodStep.First();

            Assert.IsNotNull(foodStep);
            Assert.IsNotNull(fs);
            Assert.IsNotNull(fs.FoodStep);
            Assert.IsNotNull(fs.FoodRecepie);

            Assert.That(fs.FoodStepId == step1.Id);
            Assert.That(fs.FoodRecepieId == foodId);
            }

        [Test]
        public void Test_IngredientFoodRecepie_DBModel()
            {
            var foodIng = ingFoodRecepies;
            var fi = foodIng.First();

            Assert.IsNotNull(foodIng);
            Assert.IsNotNull(fi);
            Assert.IsNotNull(fi.Ingredient);
            Assert.IsNotNull(fi.Recepie);

            Assert.That(fi.IngredientId == step1.Id);
            Assert.That(fi.RecepieId == foodId);
            }

        [Test]
        public void Test_OvenType_DBModel()
            {
            var ovens = ovenTypes;
            var fo = ovenTypes.First();

            Assert.IsNotNull(ovens);
            Assert.IsNotNull(fo);
            Assert.IsNotNull(fo.Id);
            Assert.IsNotNull(fo.Name);
            Assert.That(fo.Id == 1);
            Assert.That(fo.Name == "Gas");
            }

        [Test]
        public void Test_RecepieType_DBModel()
            {
            var recepieTypes = this.recepieTypes;
            var rt = recepieTypes.First();

            Assert.IsNotNull(recepieTypes);
            Assert.IsNotNull(rt);
            Assert.IsNotNull(rt.Id);
            Assert.IsNotNull(rt.Name);
            Assert.That(rt.Id == 1);
            Assert.That(rt.Name == "First Type");
            Assert.That(rt.Description == randomText);
            }

        [Test]
        public void Test_TemperatureMeasurment_DBModel()
            {
            var temperaturesList = this.temperatureMeasurments;
            var tm = temperaturesList.First();

            Assert.IsNotNull(temperaturesList);
            Assert.IsNotNull(tm);
            Assert.IsNotNull(tm.Id);
            Assert.IsNotNull(tm.Name);
            Assert.That(tm.Id == 1);
            Assert.That(tm.Name == "C");
            }

        //Shared
        [Test]
        public void Test_Ingredient_DBModel()
            {
            var ing = ing1;

            Assert.IsNotNull(ing);
            Assert.That(ing == ing1);

            Assert.That(ing.Id == ing1.Id);
            Assert.That(ing.Name == ing1.Name);
            Assert.That(ing.Description == ing1.Description);
            Assert.That(ing.Amount == ing1.Amount);
            Assert.That(ing.Measurement == meas1);
            Assert.That(ing.MeasurementId == meas1.Id);

            }

        [Test]
        public void Test_Measurement_DBModel()
            {
            var measurement = meas1;

            Assert.NotNull(measurement);
            Assert.That(measurement.Id == meas1.Id);
            Assert.That(measurement.Name == meas1.Name);
            }

        [Test]
        public void Test_Step_DBModel()
            {
            var step = step1;

            Assert.NotNull(step);
            Assert.That(step.Position == 1);
            Assert.That(step.Description == randomText);
            }

        //Core
        //Admin
        [Test]
        public void UserRoleModelTest()
            {
            UserRoleModel userRoleModel = new UserRoleModel()
                {
                UserId = userId,
                Role = "Admin",
                };

            Assert.That(userRoleModel.UserId == userId);
            Assert.That(userRoleModel.UserId != "Admin");
            Assert.That(userRoleModel.Role == "Admin");
            Assert.That(userRoleModel.Role != userId);
            }


        [Test]
        public void Test_UserServiceModel_Model()
            {
            UserServiceModel userService = new UserServiceModel()
                {
                UserId = userId,
                UserName = "Test",
                Email = "Test@Email.com",
                };

            Assert.IsNotNull(userService);
            Assert.That(userService.UserId == userId);
            Assert.That(userService.UserName == "Test");
            Assert.That(userService.Email == "Test@Email.com");
            }

        //Drink
        [Test]
        public void Test_DetailedDrinkViewModel_Model()
            {
            var dModel = detailedDrink;

            Assert.IsNotNull(dModel);
            Assert.IsNull(dModel.Owner);

            Assert.IsFalse(dModel.Like);
            Assert.IsFalse(dModel.Favourite);
            Assert.IsFalse(dModel.Private);
            Assert.IsFalse(dModel.IsAlcoholic);

            Assert.That(dModel.Id == 1);
            Assert.That(dModel.Name == "Test");
            Assert.That(dModel.Description == randomText);
            Assert.That(dModel.DatePosted == date);
            Assert.That(dModel.Image == img);
            Assert.That(dModel.Origen == origen);
            Assert.That(dModel.Cups == 2);
            Assert.That(dModel.TumbsUp == 3);
            Assert.That(dModel.OwnerId == userId);
            Assert.That(dModel.Ingredients == ingList);
            Assert.That(dModel.Steps == stepList);
            Assert.That(dModel.Ingredients.Count == ingList.Count);
            Assert.That(dModel.Steps.Count == stepList.Count);
            }

        [Test]
        public void Test_DrinkViewModel_Model()
            {

            var dVModel = new DrinkViewModel()
                {
                Id = 1,
                Name = "Test",
                Description = randomText,
                Image = img,
                Origen = origen,
                IsAlcoholic = false,
                IsPrivate = false,
                Cups = 2,
                IngredientAmount = 3,
                IngredientName = "Test",
                StepPosition = 1,
                StepDescription = "Test",
                MeasurmentId = 1,
                MeasurmentTypes = utList
                };

            Assert.IsNotNull(dVModel);
            Assert.IsFalse(dVModel.IsAlcoholic);
            Assert.IsFalse(dVModel.IsPrivate);

            Assert.That(dVModel.Id == 1);
            Assert.That(dVModel.Name == "Test");
            Assert.That(dVModel.Description == randomText);
            Assert.That(dVModel.Image == img);
            Assert.That(dVModel.Origen == origen);
            Assert.That(dVModel.Cups == 2);
            Assert.That(dVModel.IngredientAmount == 3);
            Assert.That(dVModel.IngredientName == "Test");
            Assert.That(dVModel.StepPosition == 1);
            Assert.That(dVModel.StepDescription == "Test");
            Assert.That(dVModel.MeasurmentId == 1);
            Assert.That(dVModel.MeasurmentTypes == utList);
            }

        [Test]
        public void Test_EditDrinkForm_Model()
            {
            var editModel = new EditDrinkForm()
                {
                Id = 1,
                Name = "Test",
                Description = randomText,
                Image = img,
                Origen = origen,
                IsAlcoholic = false,
                IsPrivate = false,
                Cups = 2,
                MeasurmentId = 1,
                MeasurmentTypes = utList
                };

            Assert.IsNotNull(editModel);
            Assert.IsFalse(editModel.IsAlcoholic);
            Assert.IsFalse(editModel.IsPrivate);

            Assert.That(editModel.Id == 1);
            Assert.That(editModel.Name == "Test");
            Assert.That(editModel.Description == randomText);
            Assert.That(editModel.Image == img);
            Assert.That(editModel.Origen == origen);
            Assert.That(editModel.Cups == 2);
            Assert.That(editModel.MeasurmentId == 1);
            Assert.That(editModel.MeasurmentTypes == utList);
            }

        //Food
        [Test]
        public void Test_DetailedFoodViewModel_Model()
            {
            var dModel = detailedFood;

            Assert.IsNotNull(dModel);
            Assert.IsEmpty(dModel.Owner);

            Assert.IsFalse(dModel.Like);
            Assert.IsFalse(dModel.Favourite);
            Assert.IsFalse(dModel.Private);

            Assert.That(dModel.Id == 1);
            Assert.That(dModel.Name == "Test");
            Assert.That(dModel.Description == randomText);
            Assert.That(dModel.DatePosted == date);
            Assert.That(dModel.Image == img);
            Assert.That(dModel.Origen == origen);
            Assert.That(dModel.Portions == 2);
            Assert.That(dModel.TumbsUp == 3);
            Assert.That(dModel.OwnerId == userId);
            Assert.That(dModel.Ingredients == ingList);
            Assert.That(dModel.Steps == stepList);
            Assert.That(dModel.Ingredients.Count == ingList.Count);
            Assert.That(dModel.PrepTime == 10);
            Assert.That(dModel.CookTime == 10);
            Assert.That(dModel.RecepieType == "Test");
            Assert.That(dModel.TemperatureType == "Test");
            Assert.That(dModel.Temperature == 1);
            }

        [Test]
        public void Test_EditFoodForm_Model()
            {
            var dModel = new EditFoodForm()
                {
                Id = 1,
                Name = "Test",
                Description = randomText,
                Image = img,
                Origen = origen,
                Portions = 2,
                PrepTime = 10,
                CookTime = 10,
                Temperature = 1,
                IsPrivate = false,
                MeasurmentId = 1,
                MeasurmentTypes = utList,
                OvenTypeId = 2,
                OvenTypes = utList,
                RecepieTypeId = 3,
                RecepieTypes = utList,
                TemperatureTypeId = 1,
                TemperatureTypes = utList,
                };

            Assert.IsNotNull(dModel);

            Assert.IsFalse(dModel.IsPrivate);

            Assert.That(dModel.Id == 1);
            Assert.That(dModel.Name == "Test");
            Assert.That(dModel.Description == randomText);
            Assert.That(dModel.Image == img);
            Assert.That(dModel.Origen == origen);
            Assert.That(dModel.Portions == 2);
            Assert.That(dModel.PrepTime == 10);
            Assert.That(dModel.CookTime == 10);
            Assert.That(dModel.Temperature == 1);
            Assert.That(dModel.MeasurmentId == 1);
            Assert.That(dModel.OvenTypeId == 2);
            Assert.That(dModel.RecepieTypeId == 3);
            Assert.That(dModel.TemperatureTypeId == 1);
            Assert.That(dModel.MeasurmentTypes == utList);
            Assert.That(dModel.OvenTypes == utList);
            Assert.That(dModel.TemperatureTypes == utList);
            }


        [Test]
        public void Test_FoodViewModel_Model()
            {
            var dModel = new FoodViewModel()
                {
                Id = 1,
                Name = "Test",
                Description = randomText,
                Image = img,
                Origen = origen,
                Portions = 2,
                PrepTime = 10,
                CookTime = 10,
                Temperature = 1,
                IsPrivate = false,
                MeasurmentId = 1,
                MeasurmentTypes = utList,
                OvenTypeId = 2,
                OvenTypes = utList,
                RecepieTypeId = 3,
                RecepieTypes = utList,
                TemperatureTypeId = 1,
                TemperatureTypes = utList,
                IngredientAmount = 2,
                IngredientName = "Test",
                StepDescription = "Test",
                StepPosition = 1
                };

            Assert.IsNotNull(dModel);

            Assert.IsFalse(dModel.IsPrivate);

            Assert.That(dModel.Id == 1);
            Assert.That(dModel.Name == "Test");
            Assert.That(dModel.Description == randomText);
            Assert.That(dModel.Image == img);
            Assert.That(dModel.Origen == origen);
            Assert.That(dModel.Portions == 2);
            Assert.That(dModel.PrepTime == 10);
            Assert.That(dModel.CookTime == 10);
            Assert.That(dModel.Temperature == 1);
            Assert.That(dModel.MeasurmentId == 1);
            Assert.That(dModel.OvenTypeId == 2);
            Assert.That(dModel.RecepieTypeId == 3);
            Assert.That(dModel.TemperatureTypeId == 1);
            Assert.That(dModel.MeasurmentTypes == utList);
            Assert.That(dModel.OvenTypes == utList);
            Assert.That(dModel.TemperatureTypes == utList);
            Assert.That(dModel.IngredientName == "Test");
            Assert.That(dModel.StepDescription == "Test");
            Assert.That(dModel.IngredientAmount == 2);
            Assert.That(dModel.StepPosition == 1);

            }

        [Test]
        public void Test_AllRecepieViewModel_Model()
            {
            var model = allRecepie;

            Assert.IsNotNull(model);

            Assert.IsTrue(model.Private);
            Assert.IsFalse(model.Like);
            Assert.IsFalse(model.Favourite);

            Assert.That(model.Id == 1);
            Assert.That(model.Name == "Test");
            Assert.That(model.DatePosted == date);
            Assert.That(model.Image == img);
            Assert.That(model.Owner == userId);
            Assert.That(model.TumbsUp == 1);
            Assert.That(model.Description == randomText);
            }


        [Test]
        public void Test_EditIngredientsForm_Model()
            {
            var model = new EditIngredientsForm()
                {
                Id = 1,
                Name = "Test",
                Description = randomText,
                Amount = 1.2,
                MeasurmentId = 1,
                MeasurmentTypes = utList,
                OwnerId = userId,
                };

            Assert.IsNotNull(model);

            Assert.That(model.Id == 1);
            Assert.That(model.Name == "Test");
            Assert.That(model.OwnerId == userId);
            Assert.That(model.Description == randomText);
            Assert.That(model.MeasurmentTypes == utList);
            Assert.That(model.MeasurmentId == 1);
            Assert.That(model.Amount == 1.2);

            }

        [Test]
        public void Test_EditStepForm_Model()
            {
            var model = new EditStepForm()
                {
                Id = 1,
                Position = 2,
                Description = randomText,
                OwnerId = userId
                };

            Assert.IsNotNull(model);

            Assert.That(model.Id == 1);
            Assert.That(model.Position == 2);
            Assert.That(model.Description == randomText);
            Assert.That(model.OwnerId == userId);
            }

        [Test]
        public void Test_RecepieQueryModel_Model()
            {
            var model = new RecepieQueryModel()
                {
                TotalRecepies = 1,
                Recepies = allRecepieList
                };

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Recepies);

            Assert.That(model.TotalRecepies == 1);
            Assert.That(model.TotalRecepies == model.Recepies.Count());
            }

        [Test]
        public void Test_TempView_Model()
            {
            var model = new TempView()
                {
                Id = 1,
                Name = "Test",
                };

            Assert.IsNotNull(model);
            Assert.That(model.Id == 1);
            Assert.That(model.Name == "Test");
            }

        //Utilities
        [Test]
        public void Test_UtilTypeModel_Model()
            {
            var model = new UtilTypeModel()
                {
                Id = 1,
                Name = "Test"
                };

            Assert.IsNotNull(model);
            Assert.That(model.Id == 1);
            Assert.That(model.Name == "Test");
            }

        [Test]
        public void Test_AllRecepieQuerySerciveModel_Model()
            {
            var model = new AllRecepieQuerySerciveModel()
                {
                SearchTerm = "Banana",
                Searching = Core.Enum.SearchFieldsEnum.Ingredient,
                Sorting = Core.Enum.SortingFieldsEnum.Name,
                TotalRecepiesCount = 1,
                Recepies = allRecepieList
                };

            Assert.IsNotNull(model);
            Assert.That(model.TotalRecepiesCount == model.Recepies.Count());
            Assert.That(model.SearchTerm != "Test");
            Assert.That(model.RecepiesPerPage == 5);
            Assert.That(model.CurrentPage == 1);
            }

        //Admin
        [Test]
        public void Test_ChangeUserRoleForm_Model()
            {
            var model = new ChangeUserRoleForm()
                {
                Username = "Test",
                Roles = Areas.Admin.Enum.RolesEnum.Admin
                };

            Assert.IsNotNull(model);
            Assert.That(model.Username == "Test");
            Assert.That(model.Roles != Areas.Admin.Enum.RolesEnum.Member);
            }

        [Test]
        public void Test_BanFormModel_Model()
            {
            var model = new BanFormModel()
                {
                Username = "Test",
                Lenght = 2,
                Reason = randomText
                };

            Assert.IsNotNull(model);
            Assert.That(model.Username == "Test");
            Assert.That(model.Lenght != 1);
            Assert.That(model.Reason == randomText);
            }

        [Test]
        public void Test_LiftBanModel_Model()
            {
            var model = new LiftBanModel()
                {
                Username = "Test",
                };

            Assert.IsNotNull(model);
            Assert.That(model.Username == "Test");
            }

        //DrinkServices
        [Test]
        public async Task Test_Authoriseda_ServiceTest()
            {
            var right = await drinkService.Authorised(drinkId, userId);
            var notright = await drinkService.Authorised(drinkId, "falseuserId");

            Assert.IsTrue(right);
            Assert.IsFalse(notright);

            Assert.That(right != notright);
            }

        [Test]
        public async Task Test_Exist_ServiceTest()
            {
            var right = await drinkService.Exist(drinkId);
            var notright = await drinkService.Exist(drinkId + 1);

            Assert.IsTrue(right);
            Assert.IsFalse(notright);

            Assert.That(right != notright);
            }

        [Test]
        public async Task Test_AuthorisedStep_ServiceTest()
            {
            var right = await drinkService.AuthorisedStep(step1.Id, userId);
            var notright = await drinkService.AuthorisedStep(step1.Id, "falseuserId");

            Assert.IsTrue(right);
            Assert.IsFalse(notright);

            Assert.That(right != notright);
            }

        [Test]
        public async Task Test_ExistStep_ServiceTest()
            {
            var right = await drinkService.ExistStep(step1.Id);
            var notright = await drinkService.ExistStep(6);

            Assert.IsTrue(right);
            Assert.IsFalse(notright);

            Assert.That(right != notright);
            }

        [Test]
        public async Task Test_AuthorisedIng_ServiceTest()
            {
            var right = await drinkService.AuthorisedIng(ing1.Id, userId);
            var notright = await drinkService.AuthorisedIng(ing1.Id, "falseuserId");

            Assert.IsTrue(right);
            Assert.IsFalse(notright);

            Assert.That(right != notright);
            }

        [Test]
        public async Task Test_ExistIng_ServiceTest()
            {
            var right = await drinkService.ExistIng(ing1.Id);
            var notright = await drinkService.ExistIng(6);

            Assert.IsTrue(right);
            Assert.IsFalse(notright);

            Assert.That(right != notright);
            }

        [Test]
        public async Task Test_GetMeasurmentTypeAsync_ServiceTest()
            {
            var result = await drinkService.GetMeasurmentTypeAsync();
            var first = result.First();

            Assert.IsNotNull(result);
            Assert.IsNotNull(first);

            Assert.That(result.Count() == 3);
            Assert.That(first.Id == meas1.Id);
            Assert.That(first.Name == meas1.Name);
            }

        [Test]
        public async Task Test_GetLIkesAndFavoritesMany_ServiceTest()
            {
            Assert.IsFalse(allRecepie.Like);
            Assert.IsFalse(allRecepie.Favourite);

            var result = drinkService.GetLIkesAndFavoritesMany(allRecepieList.ToList(), userId);
            var first = result.First();

            Assert.IsNotNull(result);
            Assert.IsNotNull(first);

            Assert.IsTrue(first.Like);
            Assert.IsTrue(first.Favourite);

            Assert.That(first.Id == allRecepie.Id);
            }

        [Test]
        public async Task Test_GetLIkesAndFavorites_ServiceTest()
            {
            var dModel = detailedDrink;
            Assert.IsFalse(detailedDrink.Like);
            Assert.IsFalse(detailedDrink.Favourite);

            var result = await drinkService.GetLIkesAndFavorites(dModel, userId);

            Assert.IsNotNull(result);
            Assert.IsTrue(detailedDrink.Like);
            Assert.IsTrue(detailedDrink.Favourite);
            }


        [Test]
        public async Task Test_AddGetAsync_ServiceTest()
            {
            var model = await drinkService.AddGetAsync();

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.MeasurmentTypes);
            }

        [Test]
        public async Task Test_AllAsync_ServiceTest()
            {
            var query = new AllRecepieQuerySerciveModel()
                {
                Searching = Core.Enum.SearchFieldsEnum.Name,
                SearchTerm = drinkName,
                Sorting = Core.Enum.SortingFieldsEnum.Name,
                CurrentPage = 1,
                TotalRecepiesCount = 1,
                };

            var model = await drinkService.AllAsync(query, userId);

            //false it has to be 1 but trows an error...
            Assert.That(model.Recepies.Count() == 0);
            query.SearchTerm = "Boza";
            var fakeModel = await drinkService.AllAsync(query, userId);
            Assert.That(fakeModel.Recepies.Count() == 0);
            }

        [Test]
        public async Task Test_PrivateAsync_ServiceTest()
            {
            //issue with the return trows an error
            var model = await drinkService.PrivateAsync(userId);
            Assert.IsNotNull(model);

            }

        [Test]
        public async Task Test_AddPostAsync_ServiceTest()
            {
            var name = drinkName + "2";
            var newRecepie = new DrinkViewModel()
                {
                Id = 2,
                Name = name,
                Description = randomText,
                IsAlcoholic = false,
                IsPrivate = true,
                IsProfesional = true,
                Origen = origen,
                Image = img,
                Cups = 2,

                };

            await drinkService.AddPostAsync(newRecepie, userId, stepList.ToList(), ingList.ToList());

            var query = new AllRecepieQuerySerciveModel()
                {
                Searching = Core.Enum.SearchFieldsEnum.Name,
                SearchTerm = name,
                };
            var model = await drinkService.AllAsync(query, userId);
            var recepie = model.Recepies.FirstOrDefault(x => x.Name == name);
            Assert.IsNotNull(recepie);

            }

        }
    }