using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class renameDrinkRecepiStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1fc0fcf-10db-4745-afbd-b1ea612fec16");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a3383f9f-62ef-40f6-83ed-3501d2177b19", 0, "c12e54de-8b8f-4fec-8b18-c15f50928d4c", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEIXxNFcL+o4b34+YmDcjAoI0lKudVCKy18YzlrwWvytSzibfRY66+QOgenSQgIvfRQ==", null, false, "7f460731-ff84-43f4-bdd3-ae6257b2eff4", false, "test@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3383f9f-62ef-40f6-83ed-3501d2177b19");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1fc0fcf-10db-4745-afbd-b1ea612fec16", 0, "c8718ac4-6ee2-43c3-b78a-5fec4e63818d", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEGJRekNC5StJZBN8tWKXiHG1W245f8lLRCIiEM+5g5MdkCw8PktgtsX/p+z9oVu7Kw==", null, false, "03dd4cf3-2ae7-4179-b391-988b16a77b38", false, "test@test.com" });
        }
    }
}
