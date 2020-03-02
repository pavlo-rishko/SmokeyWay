using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class fixedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvalialable",
                table: "Dish");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Dish",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Dish");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvalialable",
                table: "Dish",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
