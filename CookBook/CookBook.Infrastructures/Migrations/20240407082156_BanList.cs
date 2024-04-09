using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Infrastructures.Migrations
    {
    public partial class BanList : Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.CreateTable(
                name: "BanedUsers",
                columns: table => new
                    {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsBaned = table.Column<bool>(type: "bit", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanedUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BanedUsers_UserId",
                table: "BanedUsers",
                column: "UserId");
            }

        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.DropTable(
                name: "BanedUsers");

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
            }
        }
    }
