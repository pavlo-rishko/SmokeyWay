using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CascadeDeletionOfflineReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfflineTableReservation_Employee_EmployeeId",
                table: "OfflineTableReservation");

            migrationBuilder.AddForeignKey(
                name: "FK_OfflineTableReservation_Employee_EmployeeId",
                table: "OfflineTableReservation",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfflineTableReservation_Employee_EmployeeId",
                table: "OfflineTableReservation");

            migrationBuilder.AddForeignKey(
                name: "FK_OfflineTableReservation_Employee_EmployeeId",
                table: "OfflineTableReservation",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
