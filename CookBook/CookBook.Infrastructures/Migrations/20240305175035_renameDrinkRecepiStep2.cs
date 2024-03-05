using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class renameDrinkRecepiStep2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkRecepiesDrinkSteps_DrinkRecepies_DrinkRecepieId",
                table: "DrinkRecepiesDrinkSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_DrinkRecepiesDrinkSteps_DrinkStep_StepId",
                table: "DrinkRecepiesDrinkSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrinkRecepiesDrinkSteps",
                table: "DrinkRecepiesDrinkSteps");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3383f9f-62ef-40f6-83ed-3501d2177b19");

            migrationBuilder.RenameTable(
                name: "DrinkRecepiesDrinkSteps",
                newName: "DrinkStepsDrinkRecepies");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkRecepiesDrinkSteps_StepId",
                table: "DrinkStepsDrinkRecepies",
                newName: "IX_DrinkStepsDrinkRecepies_StepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrinkStepsDrinkRecepies",
                table: "DrinkStepsDrinkRecepies",
                columns: new[] { "DrinkRecepieId", "StepId" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "37634a73-6e28-4a03-a91d-f0fa0d1cf209", 0, "220c6a02-a005-4d67-8343-baa2ccff3cee", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAENkLD+n1e2UXwf2gGou+qKDsf2UFOLBH04pHD46GAYVQN0jP3D7a0yd2Oeh/Do9Hfw==", null, false, "a76f3c2e-aea6-4d48-a883-df1a96866406", false, "test@test.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkStepsDrinkRecepies_DrinkRecepies_DrinkRecepieId",
                table: "DrinkStepsDrinkRecepies",
                column: "DrinkRecepieId",
                principalTable: "DrinkRecepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkStepsDrinkRecepies_DrinkStep_StepId",
                table: "DrinkStepsDrinkRecepies",
                column: "StepId",
                principalTable: "DrinkStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkStepsDrinkRecepies_DrinkRecepies_DrinkRecepieId",
                table: "DrinkStepsDrinkRecepies");

            migrationBuilder.DropForeignKey(
                name: "FK_DrinkStepsDrinkRecepies_DrinkStep_StepId",
                table: "DrinkStepsDrinkRecepies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrinkStepsDrinkRecepies",
                table: "DrinkStepsDrinkRecepies");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "37634a73-6e28-4a03-a91d-f0fa0d1cf209");

            migrationBuilder.RenameTable(
                name: "DrinkStepsDrinkRecepies",
                newName: "DrinkRecepiesDrinkSteps");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkStepsDrinkRecepies_StepId",
                table: "DrinkRecepiesDrinkSteps",
                newName: "IX_DrinkRecepiesDrinkSteps_StepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrinkRecepiesDrinkSteps",
                table: "DrinkRecepiesDrinkSteps",
                columns: new[] { "DrinkRecepieId", "StepId" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a3383f9f-62ef-40f6-83ed-3501d2177b19", 0, "c12e54de-8b8f-4fec-8b18-c15f50928d4c", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEIXxNFcL+o4b34+YmDcjAoI0lKudVCKy18YzlrwWvytSzibfRY66+QOgenSQgIvfRQ==", null, false, "7f460731-ff84-43f4-bdd3-ae6257b2eff4", false, "test@test.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkRecepiesDrinkSteps_DrinkRecepies_DrinkRecepieId",
                table: "DrinkRecepiesDrinkSteps",
                column: "DrinkRecepieId",
                principalTable: "DrinkRecepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkRecepiesDrinkSteps_DrinkStep_StepId",
                table: "DrinkRecepiesDrinkSteps",
                column: "StepId",
                principalTable: "DrinkStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
