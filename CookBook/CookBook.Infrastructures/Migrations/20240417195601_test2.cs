using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                table: "FoodRecepies");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ingredients",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43726194-6beb-463f-a562-66a48b6646db", "AQAAAAEAACcQAAAAECSbbYxujGw8VAn7N6B2ljedFvqWb4txqG5VII3L7qSmj+JYPYy/ByllgJ1m5Z0g8g==", "8324a2c8-4171-4bd8-b628-1bf8f5c6c227" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "788bfa79-40d2-489d-a1dc-21a21dc23d96", "AQAAAAEAACcQAAAAEM61QuzPrIFNx8BOrWOpIWmV7m63tHoivlKYyxggMUdkcvb6vvwis0zYECkQIMZ7Kw==", "884e2290-2d7e-4875-9cb2-e1d1284e882b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "600a5fcc-9281-48d1-b44e-ffccbbcfebc8", "AQAAAAEAACcQAAAAEMpkPiBhLZrpVWpZmpP6SnPoWHWCBhG9Fq+a41CIvQTCqb3ewfhtLJcSJom7ZbYUKQ==", "ed635550-87ac-482b-8bf8-283b95bb3dad" });

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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ingredients",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad5e1919-3ac2-4bba-bcb0-c344b107b29e", "AQAAAAEAACcQAAAAEH/PpBuIrd2Cl0aJDPZZAx4IlYX9t6wEGq0y4xZtJAqMUshqJeQOzgaVevN9xrPwIg==", "b0298b1b-3905-427f-b198-e70480b37109" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adc53fb9-c990-449b-883c-bd8928d5efdc", "AQAAAAEAACcQAAAAEJZy1iGS5jXklBzvVzTRy/AqUIw7KuVUidVT+tpv9jwTt6kNqXOALgX6xeVVu41LUA==", "c3eb58d8-9c05-4496-8114-8c92c203c6ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ff9633a-f6cf-4757-9ad0-bc32dad865f7", "AQAAAAEAACcQAAAAEDVTbWuJCTe0doOrT+bTYKQD/sRzkRwTs/vtFYIlbAf2NknSJEHJMWRwj0tVz+6elA==", "e9e14d44-2439-4f1e-a80b-99ad08780ef8" });

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
