using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
    {
    public partial class ProRecepie : Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49ec3dac-49bf-4d50-a7c1-c7f1fae6619d");

            migrationBuilder.AddColumn<bool>(
                name: "IsProfesional",
                table: "FoodRecepies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProfesional",
                table: "DrinkRecepies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bbd13a3c-8547-4d6d-b7d0-a89322b762fd", 0, "ec77f22a-28b7-4c2b-b060-fb7a0a5a2ea0", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEHkPSf6iIM6dxPxcm5730c3N8FZxz0v1mQpdJ7o4sHmLsVoHQT7t0C0eMflDONYzWg==", null, false, "5a0ce916-b89a-488b-9f13-6beba0159db2", false, "test@test.com" });
            }

        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd");

            migrationBuilder.DropColumn(
                name: "IsProfesional",
                table: "FoodRecepies");

            migrationBuilder.DropColumn(
                name: "IsProfesional",
                table: "DrinkRecepies");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "49ec3dac-49bf-4d50-a7c1-c7f1fae6619d", 0, "9713b3d2-13c4-4c93-8312-03bf3a16d480", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEC576KHkarATRYApJARmrUe/EBFBBwW6zLOzk5sMUaDScD25/Z6naRBxlw6i+lpwNg==", null, false, "c15f112f-da6b-4ec1-917a-805694bf9f6a", false, "test@test.com" });
            }
        }
    }
