using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
    {
    public partial class initial : Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                    {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                    {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkStep",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
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
                    Position = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OvenTypes",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvenTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecepieTypes",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecepieTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemperaturesMeasurments",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperaturesMeasurments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                    {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                    {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                    {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrinkRecepies",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripton = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAlcoholic = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TumbsUp = table.Column<int>(type: "int", nullable: false),
                    Cups = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkRecepies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkRecepies_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    MeasurementId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Measurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRecepies",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripton = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PrepTime = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TumbsUp = table.Column<int>(type: "int", nullable: false),
                    CookTime = table.Column<int>(type: "int", nullable: false),
                    Portions = table.Column<int>(type: "int", nullable: false),
                    RecepieTypeId = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    TemperatureMeasurmentId = table.Column<int>(type: "int", nullable: false),
                    OvenTypeId = table.Column<int>(type: "int", nullable: false),
                    LastTimeYouHadIt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecepies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodRecepies_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodRecepies_OvenTypes_OvenTypeId",
                        column: x => x.OvenTypeId,
                        principalTable: "OvenTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRecepies_RecepieTypes_RecepieTypeId",
                        column: x => x.RecepieTypeId,
                        principalTable: "RecepieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRecepies_TemperaturesMeasurments_TemperatureMeasurmentId",
                        column: x => x.TemperatureMeasurmentId,
                        principalTable: "TemperaturesMeasurments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrinkLikeUsers",
                columns: table => new
                    {
                    DrinkRecepieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkLikeUsers", x => new { x.DrinkRecepieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_DrinkLikeUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DrinkLikeUsers_DrinkRecepies_DrinkRecepieId",
                        column: x => x.DrinkRecepieId,
                        principalTable: "DrinkRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DrinksRecepiesUsers",
                columns: table => new
                    {
                    DrinkRecepieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinksRecepiesUsers", x => new { x.DrinkRecepieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_DrinksRecepiesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DrinksRecepiesUsers_DrinkRecepies_DrinkRecepieId",
                        column: x => x.DrinkRecepieId,
                        principalTable: "DrinkRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DrinkStepsDrinkRecepies",
                columns: table => new
                    {
                    DrinkRecepieId = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkStepsDrinkRecepies", x => new { x.DrinkRecepieId, x.StepId });
                    table.ForeignKey(
                        name: "FK_DrinkStepsDrinkRecepies_DrinkRecepies_DrinkRecepieId",
                        column: x => x.DrinkRecepieId,
                        principalTable: "DrinkRecepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkStepsDrinkRecepies_DrinkStep_StepId",
                        column: x => x.StepId,
                        principalTable: "DrinkStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteDrinkRecepiesUsers",
                columns: table => new
                    {
                    DrinkRecepieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteDrinkRecepiesUsers", x => new { x.DrinkRecepieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteDrinkRecepiesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavouriteDrinkRecepiesUsers_DrinkRecepies_DrinkRecepieId",
                        column: x => x.DrinkRecepieId,
                        principalTable: "DrinkRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientDrinkRecepies",
                columns: table => new
                    {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecepieId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientDrinkRecepies", x => new { x.IngredientId, x.RecepieId });
                    table.ForeignKey(
                        name: "FK_IngredientDrinkRecepies_DrinkRecepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "DrinkRecepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientDrinkRecepies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteFoodRecepiesUsers",
                columns: table => new
                    {
                    FoodRecepieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteFoodRecepiesUsers", x => new { x.FoodRecepieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteFoodRecepiesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavouriteFoodRecepiesUsers_FoodRecepies_FoodRecepieId",
                        column: x => x.FoodRecepieId,
                        principalTable: "FoodRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodLikeUsers",
                columns: table => new
                    {
                    FoodRecepieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodLikeUsers", x => new { x.FoodRecepieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FoodLikeUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodLikeUsers_FoodRecepies_FoodRecepieId",
                        column: x => x.FoodRecepieId,
                        principalTable: "FoodRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodRecepiesUsers",
                columns: table => new
                    {
                    FoodRecepieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecepiesUsers", x => new { x.FoodRecepieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FoodRecepiesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodRecepiesUsers_FoodRecepies_FoodRecepieId",
                        column: x => x.FoodRecepieId,
                        principalTable: "FoodRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodStepsFoodRecepies",
                columns: table => new
                    {
                    FoodRecepieId = table.Column<int>(type: "int", nullable: false),
                    FoodStepId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStepsFoodRecepies", x => new { x.FoodRecepieId, x.FoodStepId });
                    table.ForeignKey(
                        name: "FK_FoodStepsFoodRecepies_FoodRecepies_FoodRecepieId",
                        column: x => x.FoodRecepieId,
                        principalTable: "FoodRecepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodStepsFoodRecepies_FoodStep_FoodStepId",
                        column: x => x.FoodStepId,
                        principalTable: "FoodStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientFoodRecepies",
                columns: table => new
                    {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecepieId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientFoodRecepies", x => new { x.IngredientId, x.RecepieId });
                    table.ForeignKey(
                        name: "FK_IngredientFoodRecepies_FoodRecepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "FoodRecepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientFoodRecepies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "49ec3dac-49bf-4d50-a7c1-c7f1fae6619d", 0, "9713b3d2-13c4-4c93-8312-03bf3a16d480", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEC576KHkarATRYApJARmrUe/EBFBBwW6zLOzk5sMUaDScD25/Z6naRBxlw6i+lpwNg==", null, false, "c15f112f-da6b-4ec1-917a-805694bf9f6a", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Each" },
                    { 2, "Gram" },
                    { 3, "Kilograms" },
                    { 4, "Table spoon" },
                    { 5, "Cups" },
                    { 6, "Milliliter" },
                    { 7, "Liter" },
                    { 8, "Pinch" },
                    { 9, "Ounce" },
                    { 20, "To taste" }
                });

            migrationBuilder.InsertData(
                table: "OvenTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "No oven needed" },
                    { 2, "Conventional" },
                    { 3, "Fan" },
                    { 4, "Gas" }
                });

            migrationBuilder.InsertData(
                table: "RecepieTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A salad is a dish consisting of mixed ingredients, frequently vegetables. They are typically served chilled or at room temperature, though some can be served warm. Condiments and salad dressings, which exist in a variety of flavors, are often used to enhance a salad.", "Salad" },
                    { 2, "Soup is a primarily liquid food, generally served warm or hot (but may be cool or cold), that is made by combining ingredients of meat or vegetables with stock, milk, or water. Hot soups are additionally characterized by boiling solid ingredients in liquids in a pot until the flavors are extracted, forming a broth.", "Soup" },
                    { 3, "pastry, stiff dough made from flour, salt, a relatively high proportion of fat, and a small proportion of liquid. It may also contain sugar or flavourings. Most pastry is leavened only by the action of steam, but Danish pastry is raised with yeast.", "Pastry" },
                    { 4, "A stew is a combination of solid food ingredients that have been cooked in liquid and served in the resultant gravy. Ingredients can include any combination of vegetables and may include meat, especially tougher meats suitable for slow-cooking, such as beef, pork, venison, rabbit, lamb, poultry, sausages, and seafood.", "Stew" },
                    { 20, "", "Other" }
                });

            migrationBuilder.InsertData(
                table: "TemperaturesMeasurments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ºC" },
                    { 2, "ºF" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkLikeUsers_UserId",
                table: "DrinkLikeUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkRecepies_OwnerId",
                table: "DrinkRecepies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinksRecepiesUsers_UserId",
                table: "DrinksRecepiesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkStepsDrinkRecepies_StepId",
                table: "DrinkStepsDrinkRecepies",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteDrinkRecepiesUsers_UserId",
                table: "FavouriteDrinkRecepiesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteFoodRecepiesUsers_UserId",
                table: "FavouriteFoodRecepiesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodLikeUsers_UserId",
                table: "FoodLikeUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecepies_OvenTypeId",
                table: "FoodRecepies",
                column: "OvenTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecepies_OwnerId",
                table: "FoodRecepies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecepies_RecepieTypeId",
                table: "FoodRecepies",
                column: "RecepieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecepies_TemperatureMeasurmentId",
                table: "FoodRecepies",
                column: "TemperatureMeasurmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecepiesUsers_UserId",
                table: "FoodRecepiesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodStepsFoodRecepies_FoodStepId",
                table: "FoodStepsFoodRecepies",
                column: "FoodStepId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientDrinkRecepies_RecepieId",
                table: "IngredientDrinkRecepies",
                column: "RecepieId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientFoodRecepies_RecepieId",
                table: "IngredientFoodRecepies",
                column: "RecepieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MeasurementId",
                table: "Ingredients",
                column: "MeasurementId");
            }

        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DrinkLikeUsers");

            migrationBuilder.DropTable(
                name: "DrinksRecepiesUsers");

            migrationBuilder.DropTable(
                name: "DrinkStepsDrinkRecepies");

            migrationBuilder.DropTable(
                name: "FavouriteDrinkRecepiesUsers");

            migrationBuilder.DropTable(
                name: "FavouriteFoodRecepiesUsers");

            migrationBuilder.DropTable(
                name: "FoodLikeUsers");

            migrationBuilder.DropTable(
                name: "FoodRecepiesUsers");

            migrationBuilder.DropTable(
                name: "FoodStepsFoodRecepies");

            migrationBuilder.DropTable(
                name: "IngredientDrinkRecepies");

            migrationBuilder.DropTable(
                name: "IngredientFoodRecepies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DrinkStep");

            migrationBuilder.DropTable(
                name: "FoodStep");

            migrationBuilder.DropTable(
                name: "DrinkRecepies");

            migrationBuilder.DropTable(
                name: "FoodRecepies");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OvenTypes");

            migrationBuilder.DropTable(
                name: "RecepieTypes");

            migrationBuilder.DropTable(
                name: "TemperaturesMeasurments");

            migrationBuilder.DropTable(
                name: "Measurements");
            }
        }
    }
