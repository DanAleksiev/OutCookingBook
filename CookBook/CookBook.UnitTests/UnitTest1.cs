using CookBook.Core.Models.Admin;
using CookBook.Infrastructures.Data.Models.Admin;
using CookBook.Infrastructures.Data.Models.Drinks;

namespace CookBook.UnitTests
    {
    [TestFixture]
    public class Tests
        {
        private string userId = "TestingUserNotExistingID123";
        private bool isBanned = false;
        private int lenght = 1;
        private string reason = "The reason he is baned is writen here and it should be between 10 and 200 chars long";
        private DateTime date = DateTime.Parse("12/02/1993");

        private int drinkId = 1;

        private int foodkId = 2;

        //[SetUp]
        //public void TestInit()
        //    {

        //    }

        //Infrastructure
        //Admin
        [Test]
        public void BanedUserDBModel()
            {
            BanedUsers user = new BanedUsers()
                {
                UserId = userId,
                IsBaned = isBanned,
                Lenght = lenght,
                BanDate = date,
                Reason = reason
                };

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(date, user.BanDate);
            Assert.IsFalse(isBanned);
            Assert.AreEqual(reason, user.Reason);
            }

        //Drink
        [Test]
        public void DrinkLikeUserDbModel()
            {
            DrinkLikeUser drinkLikeUser = new DrinkLikeUser()
                {
                UserId = userId,
                DrinkRecepieId = drinkId
                };


            Assert.That(drinkLikeUser != null);
            Assert.That(drinkLikeUser.UserId == userId);
            Assert.That(drinkLikeUser.DrinkRecepieId != foodkId);
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