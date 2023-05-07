using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseBurger.Migrations
{
    /// <inheritdoc />
    public partial class DBver3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Staffs_StaffID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StaffID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "Orders",
                newName: "WarđID");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Orders",
                newName: "ShipperID");

            migrationBuilder.AddColumn<int>(
                name: "ChefID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ChefID",
                table: "Orders",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipperID",
                table: "Orders",
                column: "ShipperID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staffs_ChefID",
                table: "Orders",
                column: "ChefID",
                principalTable: "Staffs",
                principalColumn: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staffs_ShipperID",
                table: "Orders",
                column: "ShipperID",
                principalTable: "Staffs",
                principalColumn: "StaffID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Staffs_ChefID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Staffs_ShipperID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ChefID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipperID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ChefID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "WarđID",
                table: "Orders",
                newName: "StaffID");

            migrationBuilder.RenameColumn(
                name: "ShipperID",
                table: "Orders",
                newName: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StaffID",
                table: "Orders",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staffs_StaffID",
                table: "Orders",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
