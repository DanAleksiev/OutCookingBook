using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9e5436fb-de36-4b78-aef2-140d431f9062", "test@test.com", null, "AQAAAAEAACcQAAAAEIPkFSxGZPd8WPLwKTMBdvRAKoggen4xE/iUANIqEx+A8e9wBZJCsJgBsXnQopbrNw==", "04fb3267-177f-4850-b94c-a3dbf634c1cb", "NotChef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "598014d6-5a1a-4b10-8246-543b8ecbc445", 0, "8c04fc40-02a8-4678-8e1b-35c0ceb10be3", "test2@test.com", false, false, null, null, "TEST2@TEST.COM", "AQAAAAEAACcQAAAAEIHp8CUieC8v3kHV29ylPkp438cboxEnsY5Sm0zm89XPPXhCSc/kNfFvmP5FSZ9pOg==", null, false, "6436c4a0-7100-486a-a25e-99939c45453b", false, "Chef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b2d13a3c-8547-4d6d-b7d0-a89322b762ra", 0, "f9736bc7-b9eb-408a-8615-b3392f442842", "admin@admin.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAtX2zmSSDqD8eMgOaIhBXKCx8It07lCzSTuVAh8wKTxb/jrhFpLkF3a+JB4Nkf+jg==", null, false, "67e94dc1-4b5d-488c-ad8f-056c90461863", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ec77f22a-28b7-4c2b-b060-fb7a0a5a2ea0", null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEHkPSf6iIM6dxPxcm5730c3N8FZxz0v1mQpdJ7o4sHmLsVoHQT7t0C0eMflDONYzWg==", "5a0ce916-b89a-488b-9f13-6beba0159db2", "test@test.com" });
        }
    }
}
