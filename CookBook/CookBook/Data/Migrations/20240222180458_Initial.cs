using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperaturesMeasurments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Recepies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrepTime = table.Column<int>(type: "int", nullable: false),
                    CookTime = table.Column<int>(type: "int", nullable: false),
                    Portions = table.Column<int>(type: "int", nullable: false),
                    RecepieTypeId = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preparation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    TemperatureMeasurmentId = table.Column<int>(type: "int", nullable: false),
                    OvenTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TumbsUp = table.Column<int>(type: "int", nullable: false),
                    LastTimeYouHadIt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepies_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recepies_OvenTypes_OvenTypeId",
                        column: x => x.OvenTypeId,
                        principalTable: "OvenTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recepies_RecepieTypes_RecepieTypeId",
                        column: x => x.RecepieTypeId,
                        principalTable: "RecepieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recepies_TemperaturesMeasurments_TemperatureMeasurmentId",
                        column: x => x.TemperatureMeasurmentId,
                        principalTable: "TemperaturesMeasurments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientRecepies",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecepieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRecepies", x => new { x.IngredientId, x.RecepieId });
                    table.ForeignKey(
                        name: "FK_IngredientRecepies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientRecepies_Recepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "Recepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecepiesUsers",
                columns: table => new
                {
                    RecepieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecepieId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecepiesUsers", x => new { x.RecepieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RecepiesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecepiesUsers_Recepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "Recepies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecepiesUsers_Recepies_RecepieId1",
                        column: x => x.RecepieId1,
                        principalTable: "Recepies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8b83546e-165a-4d46-b1e6-9620c32b8a11", 0, "775826eb-2c22-4352-b0dd-8d1c53fdf013", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEDQikFgLYobFZvXqpkgDhirW2u6XLpeEU3tVIRFin4b8i3bVuUMfK6Hk5ueXhsUb+g==", null, false, "939d3c2a-0185-450f-bd56-63271579a683", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Grams" },
                    { 2, "Table spoons" },
                    { 3, "Cups" },
                    { 4, "Ounces" }
                });

            migrationBuilder.InsertData(
                table: "OvenTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conventional" },
                    { 2, "Fan" },
                    { 3, "Gas" },
                    { 4, "No oven needed" }
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
                name: "IX_IngredientRecepies_RecepieId",
                table: "IngredientRecepies",
                column: "RecepieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MeasurementId",
                table: "Ingredients",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_OvenTypeId",
                table: "Recepies",
                column: "OvenTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_OwnerId",
                table: "Recepies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_RecepieTypeId",
                table: "Recepies",
                column: "RecepieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_TemperatureMeasurmentId",
                table: "Recepies",
                column: "TemperatureMeasurmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RecepiesUsers_RecepieId1",
                table: "RecepiesUsers",
                column: "RecepieId1");

            migrationBuilder.CreateIndex(
                name: "IX_RecepiesUsers_UserId",
                table: "RecepiesUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientRecepies");

            migrationBuilder.DropTable(
                name: "RecepiesUsers");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recepies");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "OvenTypes");

            migrationBuilder.DropTable(
                name: "RecepieTypes");

            migrationBuilder.DropTable(
                name: "TemperaturesMeasurments");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b83546e-165a-4d46-b1e6-9620c32b8a11");
        }
    }
}
