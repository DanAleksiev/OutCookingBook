using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class favError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                table: "FoodRecepies");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                table: "FoodRecepies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f713f2aa-c399-4c6f-88b0-90437e689f22", "AQAAAAEAACcQAAAAECqQYAHcy+QTVvpIN78onHrQC7W1/JI0rwZ3n35fgg3eo88tXejd6/5ikqdHJNVlaw==", "5d1e0378-9e21-492e-8863-dcb1d7c67a87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9f4c030-2f27-4f69-9b8a-f6040e6c2344", "AQAAAAEAACcQAAAAEJH+EM65aFGccaiMhQeULEGG7a1HjkZCuzsgXCPbyTlFivoZUGvB/GD/vHIWilSgKg==", "b6a9bb95-7df8-44a4-83cc-4fbacf48de2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "620a31ff-237e-430f-a09b-89eea3c954c2", "AQAAAAEAACcQAAAAEGWpxEXiionY7wCsEPYqNOJIIeeFG2I4UJOSCe980eRD3e7QLHjfO5JEO3g4zqqgdQ==", "5924d50f-b450-4abd-af23-b1807e090ed3" });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                table: "FoodRecepies",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
