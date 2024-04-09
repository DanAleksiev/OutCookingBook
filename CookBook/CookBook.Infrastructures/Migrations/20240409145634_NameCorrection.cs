using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class NameCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "faac1556-f038-4fdd-9de0-93af69d2ba30", "AQAAAAEAACcQAAAAEOmV/ZvZVO7ubm7WjMQ9xvk1q4GvkePufgwK7r9QmkSmQYzMO/Bx7C+J+FipGuivIg==", "3c5afb24-fa81-4673-a7c7-3cd65cdd0f01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5eaac24-fd6a-42a2-95cd-2329001b80ef", "AQAAAAEAACcQAAAAEGWFLmDf7AMd/TqRLFJcgLw/1c0l08O98yU/7kfcmHMxhyCcFcuIBCARM5ZMTHJAXg==", "88cc4c7b-52b5-45e9-a156-513d5a69d590" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ffacc87-e8f1-48a9-ac03-62239a88c380", "AQAAAAEAACcQAAAAELiBi2NGuR3Xeyv1wiEFDSQxH9U86A0nvE3azl9gWPb9jPWUtnwZYTBtHLc8JBxyUA==", "7332b12a-9398-477d-98d3-c181d723e897" });
        }
    }
}
