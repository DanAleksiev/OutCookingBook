using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Migrations
{
    public partial class removingTheDupForeighnKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinksRecepiesUsers_DrinkRecepies_DrinkRecepieId1",
                table: "DrinksRecepiesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteFoodRecepiesUsers_FoodRecepies_FoodRecepieId1",
                table: "FavouriteFoodRecepiesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecepiesUsers_FoodRecepies_FoodRecepieId1",
                table: "FoodRecepiesUsers");

            migrationBuilder.DropIndex(
                name: "IX_FoodRecepiesUsers_FoodRecepieId1",
                table: "FoodRecepiesUsers");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteFoodRecepiesUsers_FoodRecepieId1",
                table: "FavouriteFoodRecepiesUsers");

            migrationBuilder.DropIndex(
                name: "IX_DrinksRecepiesUsers_DrinkRecepieId1",
                table: "DrinksRecepiesUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bbabb72-de73-449d-b9dc-6fd60f562da7");

            migrationBuilder.DropColumn(
                name: "FoodRecepieId1",
                table: "FoodRecepiesUsers");

            migrationBuilder.DropColumn(
                name: "FoodRecepieId1",
                table: "FavouriteFoodRecepiesUsers");

            migrationBuilder.DropColumn(
                name: "DrinkRecepieId1",
                table: "DrinksRecepiesUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fe41dc26-4b4a-4b13-b641-bfeee2ab3f70", 0, "bb38aa05-50ba-403e-bb4d-7643cefd2ea2", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEJnqPQ3HrZch4vcvZ6CpTl242N/fo/iTXWJYbzW2mPub8mcn9oicI4/FGsixXATFdg==", null, false, "d232b4f0-a3bd-43e9-9e8d-813988c12a57", false, "test@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe41dc26-4b4a-4b13-b641-bfeee2ab3f70");

            migrationBuilder.AddColumn<int>(
                name: "FoodRecepieId1",
                table: "FoodRecepiesUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodRecepieId1",
                table: "FavouriteFoodRecepiesUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrinkRecepieId1",
                table: "DrinksRecepiesUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bbabb72-de73-449d-b9dc-6fd60f562da7", 0, "83708d6e-480b-4abb-8494-16f057f8d618", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEGerucJr3odTSwfuhc8f4ZfVslobBubTSopyPte3DTN1PxxLoHuy2zwlqfDPMyeY2g==", null, false, "417d89c2-a3aa-4e35-9fea-ac02709c6c97", false, "test@test.com" });

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecepiesUsers_FoodRecepieId1",
                table: "FoodRecepiesUsers",
                column: "FoodRecepieId1");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteFoodRecepiesUsers_FoodRecepieId1",
                table: "FavouriteFoodRecepiesUsers",
                column: "FoodRecepieId1");

            migrationBuilder.CreateIndex(
                name: "IX_DrinksRecepiesUsers_DrinkRecepieId1",
                table: "DrinksRecepiesUsers",
                column: "DrinkRecepieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinksRecepiesUsers_DrinkRecepies_DrinkRecepieId1",
                table: "DrinksRecepiesUsers",
                column: "DrinkRecepieId1",
                principalTable: "DrinkRecepies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteFoodRecepiesUsers_FoodRecepies_FoodRecepieId1",
                table: "FavouriteFoodRecepiesUsers",
                column: "FoodRecepieId1",
                principalTable: "FoodRecepies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRecepiesUsers_FoodRecepies_FoodRecepieId1",
                table: "FoodRecepiesUsers",
                column: "FoodRecepieId1",
                principalTable: "FoodRecepies",
                principalColumn: "Id");
        }
    }
}
