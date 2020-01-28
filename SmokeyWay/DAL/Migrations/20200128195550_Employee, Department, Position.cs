using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EmployeeDepartmentPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_DishType_DishTypeId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineTableReservation_Table_TableId",
                table: "OnlineTableReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineTableReservation_User_UserId",
                table: "OnlineTableReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Order_OrderId",
                table: "OrderDish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDish",
                table: "OrderDish");

            migrationBuilder.DropIndex(
                name: "IX_OrderDish_DishId",
                table: "OrderDish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_DishTypeId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderDish");

            migrationBuilder.DropColumn(
                name: "DishTypeId",
                table: "Dish");

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Table",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DishType",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dish",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dish",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDish",
                table: "OrderDish",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: true),
                    Country = table.Column<string>(maxLength: 45, nullable: true),
                    City = table.Column<string>(maxLength: 45, nullable: true),
                    Street = table.Column<string>(maxLength: 45, nullable: true),
                    HouseNumber = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: true),
                    Description = table.Column<string>(maxLength: 8000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 45, nullable: false),
                    LastName = table.Column<string>(maxLength: 45, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 45, nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeConfiguration_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeConfiguration_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeConfiguration_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_DepartmentId",
                table: "Table",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_TypeId",
                table: "Dish",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeConfiguration_DepartmentId",
                table: "EmployeeConfiguration",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeConfiguration_GenderId",
                table: "EmployeeConfiguration",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeConfiguration_PositionId",
                table: "EmployeeConfiguration",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_DishType_TypeId",
                table: "Dish",
                column: "TypeId",
                principalTable: "DishType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineTableReservation_Table_TableId",
                table: "OnlineTableReservation",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineTableReservation_User_UserId",
                table: "OnlineTableReservation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_EmployeeConfiguration_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "EmployeeConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Order_OrderId",
                table: "OrderDish",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Department_DepartmentId",
                table: "Table",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_DishType_TypeId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineTableReservation_Table_TableId",
                table: "OnlineTableReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineTableReservation_User_UserId",
                table: "OnlineTableReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_EmployeeConfiguration_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Order_OrderId",
                table: "OrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Department_DepartmentId",
                table: "Table");

            migrationBuilder.DropTable(
                name: "EmployeeConfiguration");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Table_DepartmentId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDish",
                table: "OrderDish");

            migrationBuilder.DropIndex(
                name: "IX_Order_EmployeeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Dish_TypeId",
                table: "Dish");

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Table",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderDish",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DishType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DishTypeId",
                table: "Dish",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDish",
                table: "OrderDish",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDish_DishId",
                table: "OrderDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_DishTypeId",
                table: "Dish",
                column: "DishTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_DishType_DishTypeId",
                table: "Dish",
                column: "DishTypeId",
                principalTable: "DishType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineTableReservation_Table_TableId",
                table: "OnlineTableReservation",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineTableReservation_User_UserId",
                table: "OnlineTableReservation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Order_OrderId",
                table: "OrderDish",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
