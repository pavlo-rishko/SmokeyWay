using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatedGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "OfflineTableReservation");

            migrationBuilder.DropColumn(
                name: "UserPhoneNumber",
                table: "OfflineTableReservation");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDateTime",
                table: "OnlineTableReservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "OfflineTableReservation",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientPhoneNumber",
                table: "OfflineTableReservation",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDateTime",
                table: "OfflineTableReservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Game",
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationDateTime",
                table: "OnlineTableReservation");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "OfflineTableReservation");

            migrationBuilder.DropColumn(
                name: "ClientPhoneNumber",
                table: "OfflineTableReservation");

            migrationBuilder.DropColumn(
                name: "ReservationDateTime",
                table: "OfflineTableReservation");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "OfflineTableReservation",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhoneNumber",
                table: "OfflineTableReservation",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Game",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8000,
                oldNullable: true);
        }
    }
}
