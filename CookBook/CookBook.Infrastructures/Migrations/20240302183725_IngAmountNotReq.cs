using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class IngAmountNotReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "227f0041-a2e6-4248-baa5-c1a12acfaac8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "508ce5b5-1a94-4a65-84da-89d30b9f2c62", 0, "a7fa35e0-5ce6-46f0-8c70-a493587cc669", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEIft9J2rDU+qirIboJPh1EPgVzJYNg5FWfDYO1x8lUDZEvgILtX6iibx3N8LxPBGAw==", null, false, "54c839aa-0daa-42b7-8a72-442d6a0f5764", false, "test@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "508ce5b5-1a94-4a65-84da-89d30b9f2c62");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "227f0041-a2e6-4248-baa5-c1a12acfaac8", 0, "a3d4bb34-168d-4af4-b400-1f201ed5a8df", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEO3K7hYoBZWbr0NBHIOAI/9yV7j6HpF7ZBRjLf+k2nbzbvJGXXL8UOjRikgA2C9JsQ==", null, false, "bc3f7f4e-36a7-4918-b4f0-195df479c138", false, "test@test.com" });
        }
    }
}
