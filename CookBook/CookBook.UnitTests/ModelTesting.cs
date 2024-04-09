using CookBook.Core.Models.Admin;
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


        //Ingredient
        private string ingName = "ing";


        /// <summary>
        /// prop
        /// </summary>

        //Shared
        private Step step1 = new Step();
        private Step step2 = new Step();
        private Step step3 = new Step();
        private IEnumerable<Step> steps = null!;
        private Ingredient ing1 = new Ingredient();
        private Ingredient ing2 = new Ingredient();
        private Ingredient ing3 = new Ingredient();
        private IEnumerable<Ingredient> Ingredients = null!;

        //Drink
        private DrinkRecepie drinkRecepie = new DrinkRecepie();
        private IList<DrinkStepsDrinkRecepies> drinkSteps;
        private IList<IngredientDrinkRecepie> ingDrinkRecepie;
        private ICollection<DrinkLikeUser> drinkLikes;
        private ICollection<FavouriteDrinkRecepiesUsers> favDrinkUsers;
        private ICollection<DrinkRecepiesUsers> drinkRecepiesUsers;

        //Food
        private FoodRecepie foodRecepie = new FoodRecepie();
        private ICollection<FavouriteFoodRecepiesUsers> favouriteFoodUserList;
        private ICollection<IngredientFoodRecepie> ingredientsRecepies;
        private ICollection<FoodRecepiesUsers> foodUsers;
        private ICollection<FoodStepsFoodRecepies> foodSteps;
        private ICollection<FoodLikeUser> foodLikes;


        [SetUp]
        public void TestInit()
            {
            //shared
            this.ing1 = new Ingredient()
                {
                Id = 1,
                Name = ingName + "1",
                MeasurementId = 1,
                Amount = 1,
                Description = randomText
                };

            this.ing2 = new Ingredient()
                {
                Id = 2,
                Name = ingName + "2",
                MeasurementId = 2,
                Amount = 2,
                Description = randomText
                };

            this.ing3 = new Ingredient()
                {
                Id = 3,
                Name = ingName + "3",
                MeasurementId = 3,
                Amount = 3,
                Description = randomText
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

            this.drinkRecepiesUsers = new List<DrinkRecepiesUsers>()
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
                RecepiesUsers = drinkRecepiesUsers,
                };

            //Food

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
            Assert.That(recepie.RecepiesUsers.Count == drinkRecepiesUsers.Count);
            }

        [Test]
        public void Test_DrinkRecepieUsersDBModel()
            {
            var drinkRecepieUser = drinkRecepiesUsers;
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
        public void Test_PlaceHolderCopyPaste_DBModel()
            {



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
        }
    }