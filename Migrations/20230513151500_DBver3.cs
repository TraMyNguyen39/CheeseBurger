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
            migrationBuilder.AddColumn<int>(
                name: "ProfitPercent",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "tempPrice",
                table: "Foods",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "QuantityIG",
                table: "Food_Ingredients",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitPercent",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "tempPrice",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityIG",
                table: "Food_Ingredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
