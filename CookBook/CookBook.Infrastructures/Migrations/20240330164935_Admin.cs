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
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f25cc876-29c0-442d-99e0-0205b4262a46", "test@test.com", "AQAAAAEAACcQAAAAEPeH9Ydu6FabnL9v6iP3zMcdyaoDuNqXlMcLh0NusSIo5zh48zjUyn3Bbr4zE37Tcw==", "2efe2be3-cff0-43de-a1be-7a31dc9c6f59", "NotChef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "598014d6-5a1a-4b10-8246-543b8ecbc445", 0, "f4491589-1bdb-46ec-ab44-4582e4333a40", "test2@test.com", false, false, null, null, "TEST2@TEST.COM", "AQAAAAEAACcQAAAAEAw/J4JvssH5FAIqWtcTXAQcUV6uiw/BWwULlTvka/LUd4DOpoPJK+c2s9gSmnFRsQ==", null, false, "86c9893f-fac4-45c3-9449-68e9c42fc39b", false, "Chef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b2d13a3c-8547-4d6d-b7d0-a89322b762ra", 0, "6ef8abbe-effa-4047-bdac-414860213167", "admin@admin.com", false, false, null, null, "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJue5Vbi7iWppzKhWSMJCDo0cGG35j/rak6YirG2w1FNP+zF+K2qZEDkfaS5ELuJXQ==", null, false, "3bf12e92-c18b-4b12-bcb6-bccc20e7e369", false, "Admin" });
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
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ec77f22a-28b7-4c2b-b060-fb7a0a5a2ea0", null, "AQAAAAEAACcQAAAAEHkPSf6iIM6dxPxcm5730c3N8FZxz0v1mQpdJ7o4sHmLsVoHQT7t0C0eMflDONYzWg==", "5a0ce916-b89a-488b-9f13-6beba0159db2", "test@test.com" });
        }
    }
}
