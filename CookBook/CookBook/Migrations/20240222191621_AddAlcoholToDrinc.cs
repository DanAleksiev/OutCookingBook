using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Migrations
{
    public partial class AddAlcoholToDrinc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e730f2a-3709-40e6-a8bc-6c10b871fd3a");

            migrationBuilder.AddColumn<bool>(
                name: "IsAlcoholic",
                table: "DrinkRecepies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "61d47d19-ed54-4e93-b645-94246dc157af", 0, "11527b00-1901-41ec-a927-bd6682299626", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEPE4jtLDB411z/cyWqlhSeO5w4j1DrmHM/yQmrsToJvlnS/oyFLx4fcXQU2UFT3xxQ==", null, false, "de1db299-c199-4cc0-bf0b-6a5e19046314", false, "test@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61d47d19-ed54-4e93-b645-94246dc157af");

            migrationBuilder.DropColumn(
                name: "IsAlcoholic",
                table: "DrinkRecepies");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7e730f2a-3709-40e6-a8bc-6c10b871fd3a", 0, "0450d54a-011a-4515-abc7-261896818f70", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEE736+pY4P4kTWj+ndWoltU2idzGxgI59G9IEB+OCdg32RpZakMLc+Sl+XSl7+mwqQ==", null, false, "0af6f785-aca4-4287-8d3c-409efaa258f9", false, "test@test.com" });
        }
    }
}
