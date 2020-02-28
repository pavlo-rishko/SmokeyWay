using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationDateTime",
                table: "OnlineTableReservation");

            migrationBuilder.DropColumn(
                name: "ReservationDateTime",
                table: "OfflineTableReservation");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "UserRole",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Table",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Table",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Table",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Position",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Position",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Position",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Position",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "OnlineTableReservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OnlineTableReservation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "OnlineTableReservation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "OnlineTableReservation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "OfflineTableReservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OfflineTableReservation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "OfflineTableReservation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "OfflineTableReservation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Gender",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Gender",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Gender",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Gender",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "GameConsoleType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GameConsoleType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "GameConsoleType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "GameConsoleType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "GameConsole",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GameConsole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "GameConsole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "GameConsole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Game",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "DishType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DishType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "DishType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DishType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Dish",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Dish",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Dish",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Dish",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Department",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Department",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Department",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Department",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "OnlineTableReservation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OnlineTableReservation");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "OnlineTableReservation");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "OnlineTableReservation");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "OfflineTableReservation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OfflineTableReservation");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "OfflineTableReservation");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "OfflineTableReservation");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "GameConsoleType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GameConsoleType");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "GameConsoleType");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GameConsoleType");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "GameConsole");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GameConsole");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "GameConsole");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GameConsole");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "DishType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DishType");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "DishType");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DishType");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Department");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDateTime",
                table: "OnlineTableReservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDateTime",
                table: "OfflineTableReservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
