using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseBurger.Migrations
{
    public partial class CreateDataIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData(
				table: "Ingredients",
				columns: new[] { "IngredientsId", "IngredientsName", "IngredientsPrice"
								 ,"IsDeleted","MeasureID"},
				values: new object[]
				{
					"100", "Đậu salad", "50000.000", true, "1"
				}
			);

			migrationBuilder.InsertData(
				table: "Ingredients",
				columns: new[] { "IngredientsId", "IngredientsName", "IngredientsPrice"
								 ,"IsDeleted","MeasureID"},
				values: new object[]
				{
					"101", "Thịt gà", "50000", false, "2"
				}
			);
			migrationBuilder.InsertData(
				table: "Ingredients",
				columns: new[] { "IngredientsId", "IngredientsName", "IngredientsPrice"
								 ,"IsDeleted","MeasureID"},
				values: new object[]
				{
					"102", "Đậu bắp", "50000", true, "2"
				}
			);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
