using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
{
    public partial class ajust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b4d6254-265e-4692-86ce-f001f09dd014");

            migrationBuilder.CreateTable(
                name: "DrinkStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkStep_DrinkRecepies_Id",
                        column: x => x.Id,
                        principalTable: "DrinkRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodStep_FoodRecepies_Id",
                        column: x => x.Id,
                        principalTable: "FoodRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "18b835c6-d492-4883-ac0e-1bba837878f9", 0, "765ee245-4e6d-4188-8693-ddb319f1fae7", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEI8Nqh2nJ0TRkbFQZSIY7V+GTEkDrYV11sCTPQYw1fFEIz/oGny6yEo0lUhEt6x0FA==", null, false, "1ce4449d-d9d9-4d4c-8586-067958443cb4", false, "test@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkStep");

            migrationBuilder.DropTable(
                name: "FoodStep");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18b835c6-d492-4883-ac0e-1bba837878f9");

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_DrinkRecepies_Id",
                        column: x => x.Id,
                        principalTable: "DrinkRecepies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Steps_FoodRecepies_Id",
                        column: x => x.Id,
                        principalTable: "FoodRecepies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6b4d6254-265e-4692-86ce-f001f09dd014", 0, "9198f66a-3842-47c0-a2d8-740ea66625fd", null, false, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEByqdFdc5m0VVMQJoEf3u4vuhzk+bBZom5igrw/fHgYUHsIpBJ1H0w6P7aQMZ1ckng==", null, false, "11f2c22f-b716-4d3c-9467-edda1eb3c335", false, "test@test.com" });
        }
    }
}
