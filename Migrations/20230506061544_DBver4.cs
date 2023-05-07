using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseBurger.Migrations
{
    /// <inheritdoc />
    public partial class DBver4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarđID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalMoney",
                table: "Orders",
                newName: "TempMoney");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArriveTime",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ShippingMoney",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArriveTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingMoney",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TempMoney",
                table: "Orders",
                newName: "TotalMoney");

            migrationBuilder.AddColumn<int>(
                name: "WarđID",
                table: "Orders",
                type: "int",
                nullable: true);
        }
    }
}
