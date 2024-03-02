using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class BugFixingAfterAddingIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "508ce5b5-1a94-4a65-84da-89d30b9f2c62");

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2fed703f-2696-4945-9012-e2b8178934c7", 0, "4f746109-a843-40ca-9098-55afbd5fe125", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEEfb4wc8ZTiVgAju5iVT1VkWZNfpWJkX/ft7KVg+HkjV1UY4z2e3JJGilMPnyJHV2A==", null, false, "6f6d0232-74db-4fb1-9a29-5aadf22c688a", false, "test@test.com" });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Each");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Gram");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Kilograms");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Table spoon");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Cups");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Milliliter");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Liter");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Pinch");

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Ounce" });

            migrationBuilder.UpdateData(
                table: "OvenTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "No oven needed");

            migrationBuilder.UpdateData(
                table: "OvenTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Conventional");

            migrationBuilder.UpdateData(
                table: "OvenTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Fan");

            migrationBuilder.UpdateData(
                table: "OvenTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Gas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fed703f-2696-4945-9012-e2b8178934c7");

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "508ce5b5-1a94-4a65-84da-89d30b9f2c62", 0, "a7fa35e0-5ce6-46f0-8c70-a493587cc669", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEIft9J2rDU+qirIboJPh1EPgVzJYNg5FWfDYO1x8lUDZEvgILtX6iibx3N8LxPBGAw==", null, false, "54c839aa-0daa-42b7-8a72-442d6a0f5764", false, "test@test.com" });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Gram");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kilograms");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Table spoon");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Cups");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Milliliter");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Liter");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Pinch");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Ounce");

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Name" },
                values: new object[] { 19, "Each" });

            migrationBuilder.UpdateData(
                table: "OvenTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Conventional");

            migrationBuilder.UpdateData(
                table: "OvenTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Fan");

            migrationBuilder.UpdateData(
                table: "OvenTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Gas");

            migrationBuilder.UpdateData(
                table: "OvenTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "No oven needed");
        }
    }
}
