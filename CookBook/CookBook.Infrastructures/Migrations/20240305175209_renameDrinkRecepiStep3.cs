using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class renameDrinkRecepiStep3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "37634a73-6e28-4a03-a91d-f0fa0d1cf209");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6521d05e-74e2-4291-97c2-5021228bcd37", 0, "49d2e90d-b28a-44a7-b79f-74edd3193483", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEOwUI4UyQVKG6ptRKDII0OoKmFrb9LVUDcKEHLXnWemVv+n3pmHRZzPw+2XYlmg+QA==", null, false, "25d2a96b-daa0-40ce-8b3c-4a6cb2dfa853", false, "test@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6521d05e-74e2-4291-97c2-5021228bcd37");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "37634a73-6e28-4a03-a91d-f0fa0d1cf209", 0, "220c6a02-a005-4d67-8343-baa2ccff3cee", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAENkLD+n1e2UXwf2gGou+qKDsf2UFOLBH04pHD46GAYVQN0jP3D7a0yd2Oeh/Do9Hfw==", null, false, "a76f3c2e-aea6-4d48-a883-df1a96866406", false, "test@test.com" });
        }
    }
}
