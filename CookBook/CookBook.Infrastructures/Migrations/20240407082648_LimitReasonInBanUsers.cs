using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class LimitReasonInBanUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "BanedUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "BanedUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ddca053-0a9c-4e3b-a3ca-9e46602fecda", "AQAAAAEAACcQAAAAEDS4+fBLCHSpuB4krjNuhRSHf8tOgSdkDeNrPU8yNfZcteAMBQrnZphuWSSPSTKYEA==", "693d3d95-b1c1-4be5-9ca0-9d29bb9663ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c6c35be-792b-4e53-8061-376d458d5b93", "AQAAAAEAACcQAAAAEO1zv87UO2EZFz4GkimPeg5EXPoOxEIt7L/T8DS7NMd8suWDkQqGWG+q4fPUtjNj3A==", "b64b0c0c-da12-4c61-9f0a-1b2730a72b6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b114e39-76a4-4980-a840-5c7a25801b56", "AQAAAAEAACcQAAAAEJoSnd2HFO/gLiO9XzplNEr10BLIsJd67mXiZHYfdsqFgM4FqqZxn9usUDr8Xre84Q==", "7c12582c-414d-4bf2-b77d-ff8f71c414e2" });
        }
    }
}
