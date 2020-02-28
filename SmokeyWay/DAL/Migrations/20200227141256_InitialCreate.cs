using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeConfiguration_Department_DepartmentId",
                table: "EmployeeConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeConfiguration_Gender_GenderId",
                table: "EmployeeConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeConfiguration_Position_PositionId",
                table: "EmployeeConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_EmployeeConfiguration_EmployeeId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeConfiguration",
                table: "EmployeeConfiguration");

            migrationBuilder.DropColumn(
                name: "ConsoleId",
                table: "Table");

            migrationBuilder.RenameTable(
                name: "EmployeeConfiguration",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeConfiguration_PositionId",
                table: "Employee",
                newName: "IX_Employee_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeConfiguration_GenderId",
                table: "Employee",
                newName: "IX_Employee_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeConfiguration_DepartmentId",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "GameConsoleId",
                table: "Table",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DishType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: true),
                    Description = table.Column<string>(maxLength: 45, nullable: true),
                    LicenseBeginDate = table.Column<DateTime>(nullable: false),
                    LicenseEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameConsoleType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfflineTableReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 45, nullable: true),
                    UserPhoneNumber = table.Column<string>(maxLength: 45, nullable: true),
                    ReservationDateTime = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfflineTableReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfflineTableReservation_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfflineTableReservation_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameConsole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameConsoleTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameConsole_GameConsoleType_GameConsoleTypeId",
                        column: x => x.GameConsoleTypeId,
                        principalTable: "GameConsoleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameConsoleGame",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    GameConsoleId = table.Column<int>(nullable: false)
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
                name: "IX_Table_GameConsoleId",
                table: "Table",
                column: "GameConsoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishType_Name",
                table: "DishType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GameConsole_GameConsoleTypeId",
                table: "GameConsole",
                column: "GameConsoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoleGame_GameId",
                table: "GameConsoleGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_OfflineTableReservation_EmployeeId",
                table: "OfflineTableReservation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfflineTableReservation_TableId",
                table: "OfflineTableReservation",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Gender_GenderId",
                table: "Employee",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Position_PositionId",
                table: "Employee",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_GameConsole_GameConsoleId",
                table: "Table",
                column: "GameConsoleId",
                principalTable: "GameConsole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Gender_GenderId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Position_PositionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_GameConsole_GameConsoleId",
                table: "Table");

            migrationBuilder.DropTable(
                name: "GameConsoleGame");

            migrationBuilder.DropTable(
                name: "OfflineTableReservation");

            migrationBuilder.DropTable(
                name: "GameConsole");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "GameConsoleType");

            migrationBuilder.DropIndex(
                name: "IX_Table_GameConsoleId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_DishType_Name",
                table: "DishType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "GameConsoleId",
                table: "Table");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "EmployeeConfiguration");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_PositionId",
                table: "EmployeeConfiguration",
                newName: "IX_EmployeeConfiguration_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_GenderId",
                table: "EmployeeConfiguration",
                newName: "IX_EmployeeConfiguration_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                table: "EmployeeConfiguration",
                newName: "IX_EmployeeConfiguration_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "ConsoleId",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DishType",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeConfiguration",
                table: "EmployeeConfiguration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeConfiguration_Department_DepartmentId",
                table: "EmployeeConfiguration",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeConfiguration_Gender_GenderId",
                table: "EmployeeConfiguration",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeConfiguration_Position_PositionId",
                table: "EmployeeConfiguration",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_EmployeeConfiguration_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "EmployeeConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
