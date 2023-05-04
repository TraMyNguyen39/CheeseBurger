using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseBurger.Migrations
{
    /// <inheritdoc />
    public partial class DBver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Addresses_AddressID",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Staffs",
                newName: "WardID");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_AddressID",
                table: "Staffs",
                newName: "IX_Staffs_WardID");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Customers",
                newName: "WardID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_AddressID",
                table: "Customers",
                newName: "IX_Customers_WardID");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusOdr",
                table: "Orders",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "HourseNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WardID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WardID",
                table: "Orders",
                column: "WardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Wards_WardID",
                table: "Customers",
                column: "WardID",
                principalTable: "Wards",
                principalColumn: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Wards_WardID",
                table: "Orders",
                column: "WardID",
                principalTable: "Wards",
                principalColumn: "WardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Wards_WardID",
                table: "Staffs",
                column: "WardID",
                principalTable: "Wards",
                principalColumn: "WardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Wards_WardID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Wards_WardID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Wards_WardID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WardID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "HourseNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WardID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "WardID",
                table: "Staffs",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_WardID",
                table: "Staffs",
                newName: "IX_Staffs_AddressID");

            migrationBuilder.RenameColumn(
                name: "WardID",
                table: "Customers",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_WardID",
                table: "Customers",
                newName: "IX_Customers_AddressID");

            migrationBuilder.AlterColumn<string>(
                name: "StatusOdr",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "StaffID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardID = table.Column<int>(type: "int", nullable: false),
                    NumberHouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_Wards_WardID",
                        column: x => x.WardID,
                        principalTable: "Wards",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressID",
                table: "Orders",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_WardID",
                table: "Addresses",
                column: "WardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressID",
                table: "Customers",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressID",
                table: "Orders",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Addresses_AddressID",
                table: "Staffs",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID");
        }
    }
}
