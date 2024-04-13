using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class fail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripton",
                table: "FoodRecepies",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Descripton",
                table: "DrinkRecepies",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "VerifyedLocation",
                table: "DrinkRecepies",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerifyedLocation",
                table: "DrinkRecepies");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "FoodRecepies",
                newName: "Descripton");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DrinkRecepies",
                newName: "Descripton");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9836de88-6b94-404d-8b78-7cf3fc717e47", "AQAAAAEAACcQAAAAECCvRWvA/jSOAHgTVItxSpQv0FwMJmMJPNrpc835p+x5kg1hzd1qHzleZP8TBQctuw==", "e68cbaf2-320e-491c-8838-db851d75c45b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b616077f-8046-4248-a186-1eccd3e1b679", "AQAAAAEAACcQAAAAECcGs6rcpVTs6B6jWWE3wjhOBKiaEycneg3TN/t4fXk8g9Pp3GoSWBTQRuuwvaC0Ew==", "cbd732c9-3c8b-412b-b610-4d69ac384610" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0109bdc-8d1a-4a08-90ae-08c478c2104b", "AQAAAAEAACcQAAAAEF/jJoHclGjUuwRU6lD7Hfw9lTsigvCgvK+6hlb8c6xty5Hu4Sg54yOu9tiKd7r4pg==", "1aac3afd-a8d6-42fc-9913-0097a2386dcd" });
        }
    }
}
