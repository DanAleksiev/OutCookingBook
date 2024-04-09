using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
    {
    public partial class ChangesAndDescriptions : Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkStepsDrinkRecepies_DrinkStep_StepId",
                table: "DrinkStepsDrinkRecepies");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodStepsFoodRecepies_FoodStep_FoodStepId",
                table: "FoodStepsFoodRecepies");

            migrationBuilder.DropTable(
                name: "DrinkStep");

            migrationBuilder.DropTable(
                name: "FoodStep");

            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "LastTimeYouHadIt",
                table: "FoodRecepies");

            migrationBuilder.AddColumn<bool>(
                name: "VerifyedLocation",
                table: "FoodRecepies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67f0e210-c3b1-424e-a72a-1311290831ce", "AQAAAAEAACcQAAAAEJxu14vd6T5YW8fgS/epJoR8kTRU7ty3agKvygez5izBbN9gWPhf+rau3591oFSZfQ==", "cedbdd80-6303-4ea4-94ea-63e1f73e2354" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c77c8408-d5d2-42e4-a73c-f78799b35ebb", "AQAAAAEAACcQAAAAEJSYwM7Ga3z2lCzxOo9Uk+wuU05F0Me0BwuLnD1TOoOW294E919XcYugtb+C5A4mBA==", "69f6bf49-1bed-4c0b-99dd-1a09fbc97f1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af3f662f-4de5-41b3-9e49-36f3445d9157", "AQAAAAEAACcQAAAAEMnnjYcoNzapRhq6yYkMemJYZGZrbxPvb4WWhU/lhdUFcrrXuXqSVpT6sRvOX5HUaA==", "5c0db0da-2295-4507-8b81-3fb544c16795" });

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkStepsDrinkRecepies_Step_StepId",
                table: "DrinkStepsDrinkRecepies",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodStepsFoodRecepies_Step_FoodStepId",
                table: "FoodStepsFoodRecepies",
                column: "FoodStepId",
                principalTable: "Step",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            }

        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkStepsDrinkRecepies_Step_StepId",
                table: "DrinkStepsDrinkRecepies");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodStepsFoodRecepies_Step_FoodStepId",
                table: "FoodStepsFoodRecepies");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropColumn(
                name: "VerifyedLocation",
                table: "FoodRecepies");

            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeYouHadIt",
                table: "FoodRecepies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DrinkStep",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodStep",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStep", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598014d6-5a1a-4b10-8246-543b8ecbc445",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16c9c49e-f544-4c6f-9819-e61a5a6cd095", "AQAAAAEAACcQAAAAEITEDWw5TbhXKRES4gYCH5p5LHHeeCCHr/n7xkhdBhi4rawhk+/PZEUVvOf24CLaBw==", "f558d3c5-5146-4dad-85fd-278777612b01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2d13a3c-8547-4d6d-b7d0-a89322b762ra",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51b918ea-171c-4fac-a92d-755b047ba53c", "AQAAAAEAACcQAAAAEB37k2MB+uNoxlgKwJHi4+A8X8amfZoGoQCHbjLbxCa3q8nNGf/s/CPUbIFjvdD0dQ==", "4dde6115-afd7-46ec-8b87-3d45c1e70673" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd13a3c-8547-4d6d-b7d0-a89322b762fd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36fbec4a-2363-4d36-9ea6-4e2ef89c90ae", "AQAAAAEAACcQAAAAEPwGEmufPUJQO6iNPY2jlqkwMYPNL4kWvxdvvI0pbAPJoZbCFB/QNGMZmmU11FgMPw==", "406a8324-ec88-46a3-8070-e49618438e9b" });

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkStepsDrinkRecepies_DrinkStep_StepId",
                table: "DrinkStepsDrinkRecepies",
                column: "StepId",
                principalTable: "DrinkStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodStepsFoodRecepies_FoodStep_FoodStepId",
                table: "FoodStepsFoodRecepies",
                column: "FoodStepId",
                principalTable: "FoodStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            }
        }
    }
