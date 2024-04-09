using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
    {
    public partial class test : Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.AddColumn<DateTime>(
                name: "BanDate",
                table: "BanedUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Lenght",
                table: "BanedUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.DropColumn(
                name: "BanDate",
                table: "BanedUsers");

            migrationBuilder.DropColumn(
                name: "Lenght",
                table: "BanedUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f47ccca-e253-4464-8693-c783603eff9d", "AQAAAAEAACcQAAAAEHwdPc/kEFoXxbTWoqshsnJem7ZvbccriAzx15fTWDFuqzegUeOwtm0HzWFCRiXzXQ==", "37153e46-0e95-4710-a04c-660d89ec4658" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc88e0e-04ae-4249-8880-546a5ac7711e", "AQAAAAEAACcQAAAAEFemmr3VdDwyGDn8bKEIAo3iB2MZlmNOuCIp0SrJdcpwudFsWF0S8V0/5CP38oxYSw==", "6b114109-944c-470d-8cbf-3951e1b8e6ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fa6c60d-130e-4147-bd77-71dc4e77343d", "AQAAAAEAACcQAAAAEHJ3to9aNFntxju0HUvEQqDnC+qaj21H1aKkjm2k+BBJyr+HdthrTJWvad9SXXQY7Q==", "92082abe-6cdb-4ecf-9db0-c5a74d5afc1e" });
            }
        }
    }
