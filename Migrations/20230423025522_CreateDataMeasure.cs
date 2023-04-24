using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseBurger.Migrations
{
    public partial class CreateDataMeasure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Measures_MeasureID",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measures",
                table: "Measures");

            migrationBuilder.RenameTable(
                name: "Measures",
                newName: "Measure");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measure",
                table: "Measure",
                column: "MeasureID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Measure_MeasureID",
                table: "Ingredients",
                column: "MeasureID",
                principalTable: "Measure",
                principalColumn: "MeasureID",
                onDelete: ReferentialAction.Cascade);
			migrationBuilder.InsertData(
				table: "Measure",
				columns: new[] { "MeasureID", "MeasureName" },
				values: new object[]
				{
					"1", "g"
				}
			);
			migrationBuilder.InsertData(
				table: "Measure",
				columns: new[] { "MeasureID", "MeasureName" },
				values: new object[]
				{
					"2", "kg"
				}
			);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Measure_MeasureID",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measure",
                table: "Measure");

            migrationBuilder.RenameTable(
                name: "Measure",
                newName: "Measures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measures",
                table: "Measures",
                column: "MeasureID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Measures_MeasureID",
                table: "Ingredients",
                column: "MeasureID",
                principalTable: "Measures",
                principalColumn: "MeasureID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
