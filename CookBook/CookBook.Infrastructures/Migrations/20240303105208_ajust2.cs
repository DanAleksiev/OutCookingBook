using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class ajust2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                table: "FoodRecepies");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18b835c6-d492-4883-ac0e-1bba837878f9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5d4a86f0-45c2-437f-a3a5-b7000660db4a", 0, "0d9ff00b-d11c-4f45-904b-ada33e96efba", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEAiIZ2Lc6e6z25NtwsnjJfIg4XsjwpQkBO9Q1vnPYdZHMFdNTZEQhJ9ONwf3su2sWg==", null, false, "fd975bda-9d92-4e40-80f4-1b0f05c5bb95", false, "test@test.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                table: "FoodRecepies",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                table: "FoodRecepies");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4a86f0-45c2-437f-a3a5-b7000660db4a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "18b835c6-d492-4883-ac0e-1bba837878f9", 0, "765ee245-4e6d-4188-8693-ddb319f1fae7", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEI8Nqh2nJ0TRkbFQZSIY7V+GTEkDrYV11sCTPQYw1fFEIz/oGny6yEo0lUhEt6x0FA==", null, false, "1ce4449d-d9d9-4d4c-8586-067958443cb4", false, "test@test.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                table: "FoodRecepies",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
