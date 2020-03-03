using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CascadeDeletionOnlineReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameConsole_GameConsoleType_GameConsoleTypeId",
                table: "GameConsole");

            migrationBuilder.DropTable(
                name: "GameConsoleGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameConsoleType",
                table: "GameConsoleType");

            migrationBuilder.RenameTable(
                name: "GameConsoleType",
                newName: "GameConsoleTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameConsoleTypes",
                table: "GameConsoleTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GameConsoleToGame",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    GameConsoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoleToGame", x => new { x.GameConsoleId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameConsoleToGame_GameConsole_GameConsoleId",
                        column: x => x.GameConsoleId,
                        principalTable: "GameConsole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameConsoleToGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoleToGame_GameId",
                table: "GameConsoleToGame",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameConsole_GameConsoleTypes_GameConsoleTypeId",
                table: "GameConsole",
                column: "GameConsoleTypeId",
                principalTable: "GameConsoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameConsole_GameConsoleTypes_GameConsoleTypeId",
                table: "GameConsole");

            migrationBuilder.DropTable(
                name: "GameConsoleToGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameConsoleTypes",
                table: "GameConsoleTypes");

            migrationBuilder.RenameTable(
                name: "GameConsoleTypes",
                newName: "GameConsoleType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameConsoleType",
                table: "GameConsoleType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GameConsoleGame",
                columns: table => new
                {
                    GameConsoleId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoleGame", x => new { x.GameConsoleId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameConsoleGame_GameConsole_GameConsoleId",
                        column: x => x.GameConsoleId,
                        principalTable: "GameConsole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameConsoleGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoleGame_GameId",
                table: "GameConsoleGame",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameConsole_GameConsoleType_GameConsoleTypeId",
                table: "GameConsole",
                column: "GameConsoleTypeId",
                principalTable: "GameConsoleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
