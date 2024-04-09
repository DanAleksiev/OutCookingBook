using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
    {
    public partial class AdminWithUserName : Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "36fbec4a-2363-4d36-9ea6-4e2ef89c90ae", "test@test.com", "TEST@TEST.COM", "NOTCHEF", "AQAAAAEAACcQAAAAEPwGEmufPUJQO6iNPY2jlqkwMYPNL4kWvxdvvI0pbAPJoZbCFB/QNGMZmmU11FgMPw==", "406a8324-ec88-46a3-8070-e49618438e9b", "NotChef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "598014d6-5a1a-4b10-8246-543b8ecbc445", 0, "16c9c49e-f544-4c6f-9819-e61a5a6cd095", "test2@test.com", false, false, null, "TEST2@TEST.COM", "CHEF", "AQAAAAEAACcQAAAAEITEDWw5TbhXKRES4gYCH5p5LHHeeCCHr/n7xkhdBhi4rawhk+/PZEUVvOf24CLaBw==", null, false, "f558d3c5-5146-4dad-85fd-278777612b01", false, "Chef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b2d13a3c-8547-4d6d-b7d0-a89322b762ra", 0, "51b918ea-171c-4fac-a92d-755b047ba53c", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEB37k2MB+uNoxlgKwJHi4+A8X8amfZoGoQCHbjLbxCa3q8nNGf/s/CPUbIFjvdD0dQ==", null, false, "4dde6115-afd7-46ec-8b87-3d45c1e70673", false, "Admin" });
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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ec77f22a-28b7-4c2b-b060-fb7a0a5a2ea0", null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEHkPSf6iIM6dxPxcm5730c3N8FZxz0v1mQpdJ7o4sHmLsVoHQT7t0C0eMflDONYzWg==", "5a0ce916-b89a-488b-9f13-6beba0159db2", "test@test.com" });
            }
        }
    }
