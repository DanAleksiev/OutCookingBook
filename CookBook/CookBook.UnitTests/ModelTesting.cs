using CookBook.Core.Models.Admin;
using CookBook.Core.Models.Drink;
using CookBook.Core.Models.Food;
using CookBook.Core.Models.Utilities;
using CookBook.Infrastructures.Data.Models.Admin;
using CookBook.Infrastructures.Data.Models.Drinks;
using CookBook.Infrastructures.Data.Models.Food;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.UnitTests
    {
    [TestFixture]
    public class Models
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

        //Drink
        private DrinkRecepie drinkRecepie = new DrinkRecepie();
        private ICollection<FavouriteDrinkRecepiesUsers> favDrinkUsers;
        private ICollection<IngredientDrinkRecepie> ingDrinkRecepie;
        private ICollection<DrinkRecepiesUsers> drinkUsers;
        private ICollection<DrinkStepsDrinkRecepies> drinkSteps;
        private ICollection<DrinkLikeUser> drinkLikes;

        //Food
        private FoodRecepie foodRecepie = new FoodRecepie();
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
            this.meas1 = new Measurement()
                {
                Id = 1,
                Name = "Kg",
                };

            this.meas2 = new Measurement()
                {
                Id = 2,
                Name = "Gr",
                };

            this.meas1 = new Measurement()
                {
                Id = 1,
                Name = "Ml",
                };

            this.measList = new List<Measurement>
                {
                meas1,
                meas2,
                meas3
                };

            this.ing1 = new Ingredient()
                {
                Id = 1,
                Name = ingName + "1",
                MeasurementId = 1,
                Measurement = meas1,
                Amount = 1,
                Description = randomText
                };

            this.ing2 = new Ingredient()
                {
                Id = 2,
                Name = ingName + "2",
                MeasurementId = 2,
                Measurement = meas2,
                Amount = 2,
                Description = randomText
                };

            this.ing3 = new Ingredient()
                {
                Id = 3,
                Name = ingName + "3",
                MeasurementId = 3,
                Measurement = meas3,
                Amount = 3,
                Description = randomText
                };

            this.ingList = new List<Ingredient>()
                {
                ing1,
                ing2,
                ing3,
                };



            this.step1 = new Step()
                {
                Id = 1,
                Position = 1,
                Description = randomText
                };

            this.step2 = new Step()
                {
                Id = 2,
                Position = 2,
                Description = randomText
                };

            this.step3 = new Step()
                {
                Id = 3,
                Position = 3,
                Description = randomText
                };

            this.stepList = new List<Step>()
                {
                step1,
                step2,
                step3,
                };

            this.utList = new List<UtilTypeModel>()
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

            //Drink
            this.drinkLikes = new List<DrinkLikeUser>()
                {
                new DrinkLikeUser()
                    {
                    UserId = userId,
                    DrinkRecepieId = drinkId
                    }
                };

            this.ingDrinkRecepie = new List<IngredientDrinkRecepie>()
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



            this.drinkSteps = new List<DrinkStepsDrinkRecepies>()
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

            this.favDrinkUsers = new List<FavouriteDrinkRecepiesUsers>()
                {
                new FavouriteDrinkRecepiesUsers()
                    {
                    UserId = userId,
                    DrinkRecepieId = drinkId,
                    },
                };

            this.drinkUsers = new List<DrinkRecepiesUsers>()
                {
                new DrinkRecepiesUsers()
                {
                DrinkRecepieId = drinkId,
                UserId = userId,
                }
                };

            this.drinkRecepie = new DrinkRecepie()
                {
                Id = drinkId,
                OwnerId = userId,
                Name = drinkName,
                DatePosted = date,
                Descripton = randomText,
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
            this.temperatureMeasurments = new List<TemperatureMeasurment>()
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

            this.recepieTypes = new List<RecepieType>()
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

            this.foodUsers = new List<FoodRecepiesUsers>()
                {
                new FoodRecepiesUsers()
                    {
                    FoodRecepieId = foodId,
                    UserId = userId
                    }
                };
            this.favouriteFoodUserList = new List<FavouriteFoodRecepiesUsers>()
                {
                new FavouriteFoodRecepiesUsers()
                    {
                    FoodRecepieId = foodId,
                    UserId = userId,
                    }
                };

            this.ovenTypes = new List<OvenType>()
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

            this.foodLikes = new List<FoodLikeUser>()
                {
                new FoodLikeUser()
                    {
                    FoodRecepieId = foodId,
                    UserId = userId,
                    }
                };

            this.ingFoodRecepies = new List<IngredientFoodRecepie>()
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

            this.foodSteps = new List<FoodStepsFoodRecepies>()
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

            this.foodRecepie = new FoodRecepie()
                {
                Id = foodId,
                OwnerId = userId,
                Name = foodName,
                DatePosted = date,
                Descripton = randomText,
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
                VerifyedLocation = false
                };
            }

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
            Assert.IsNull(drinkLikeUser.DrinkRecepie);

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
            Assert.That(recepie.Descripton == randomText);
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
            Assert.IsNull(firstDrinkUser.DrinkRecepie);
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
            Assert.IsNull(firstStepDrink.DrinkRecepie);

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
            Assert.IsNull(firstFav.DrinkRecepie);
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
            Assert.IsNull(firstIngDrink.Recepie);

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
            Assert.IsNull(firstFav.FoodRecepie);

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
            Assert.IsNull(firstLike.FoodRecepie);

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
            Assert.That(recepie.Descripton == randomText);
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

            Assert.IsNull(fu.FoodRecepie);
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
            Assert.IsNull(fs.FoodRecepie);

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
            Assert.IsNull(fi.Recepie);

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
        public void Test_UserServiceModel_DBModel()
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
        public void Test_DetailedDrinkViewModel_DBModel()
            {
            var dModel = new DetailedDrinkViewModel()
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
                Like = true,
                Favourite = true,
                Private = true,
                Ingredients = ingList,
                Steps = stepList
                };

            Assert.IsNotNull(dModel);
            Assert.IsNull(dModel.Owner);

            Assert.IsTrue(dModel.Like);
            Assert.IsTrue(dModel.Favourite);
            Assert.IsTrue(dModel.Private);
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
        public void Test_DrinkViewModel_DBModel()
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
        public void Test_EditDrinkForm_DBModel()
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
        public void Test_DetailedFoodViewModel_DBModel()
            {
            var dModel = new DetailedFoodViewModel()
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
                Like = true,
                Favourite = true,
                Private = true,
                Ingredients = ingList,
                Steps = stepList,
                PrepTime = 10,
                CookTime = 10,
                RecepieType = "Test",
                TemperatureType = "Test",
                Temperature = 1
                };

            Assert.IsNotNull(dModel);
            Assert.IsEmpty(dModel.Owner);

            Assert.IsTrue(dModel.Like);
            Assert.IsTrue(dModel.Favourite);
            Assert.IsTrue(dModel.Private);

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
        public void Test_PlaceHolderCopyPaste_DBModel()
            {

            }
        }
    }