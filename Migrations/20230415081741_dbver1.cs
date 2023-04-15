using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseBurgerWeb.Migrations
{
    /// <inheritdoc />
    public partial class dbver1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wards_Districts_DistrictID",
                table: "Wards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "DistrictID");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ImportOrders",
                columns: table => new
                {
                    ImportOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IOName = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    DateIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TMoneyIO = table.Column<float>(type: "real", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportOrders", x => x.ImportOrderID);
                    table.ForeignKey(
                        name: "FK_ImportOrders_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    MeasureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.MeasureID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TotalMoney = table.Column<float>(type: "real", nullable: false),
                    StatusOdr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImageFood = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodID);
                    table.ForeignKey(
                        name: "FK_Foods_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientsName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IngredientsPrice = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MeasureID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientsId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Measures_MeasureID",
                        column: x => x.MeasureID,
                        principalTable: "Measures",
                        principalColumn: "MeasureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.CustomerID, x.FoodID });
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Foods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Foods",
                columns: table => new
                {
                    OrderDetID = table.Column<int>(type: "int", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderID = table.Column<int>(type: "int", nullable: false),
                    QuantityOG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Foods", x => new { x.OrderDetID, x.FoodID });
                    table.ForeignKey(
                        name: "FK_Order_Foods_Foods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Foods_Orders_OrdersOrderID",
                        column: x => x.OrdersOrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Star = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    DateReview = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Foods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Food_Ingredients",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    QuantityIG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_Ingredients", x => new { x.FoodID, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_Food_Ingredients_Foods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Food_Ingredients_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportOrders_Ingredients",
                columns: table => new
                {
                    ImportOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientsID = table.Column<int>(type: "int", nullable: false),
                    QuantityIO = table.Column<int>(type: "int", nullable: false),
                    PriceIO = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportOrders_Ingredients", x => x.ImportOrderID);
                    table.ForeignKey(
                        name: "FK_ImportOrders_Ingredients_Ingredients_IngredientsID",
                        column: x => x.IngredientsID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_FoodID",
                table: "Carts",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Ingredients_IngredientsId",
                table: "Food_Ingredients",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryID",
                table: "Foods",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportOrders_StaffID",
                table: "ImportOrders",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportOrders_Ingredients_IngredientsID",
                table: "ImportOrders_Ingredients",
                column: "IngredientsID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MeasureID",
                table: "Ingredients",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Foods_FoodID",
                table: "Order_Foods",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Foods_OrdersOrderID",
                table: "Order_Foods",
                column: "OrdersOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressID",
                table: "Orders",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StaffID",
                table: "Orders",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerID",
                table: "Reviews",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FoodID",
                table: "Reviews",
                column: "FoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_District_DistrictID",
                table: "Wards",
                column: "DistrictID",
                principalTable: "District",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wards_District_DistrictID",
                table: "Wards");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Food_Ingredients");

            migrationBuilder.DropTable(
                name: "ImportOrders");

            migrationBuilder.DropTable(
                name: "ImportOrders_Ingredients");

            migrationBuilder.DropTable(
                name: "Order_Foods");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_Districts_DistrictID",
                table: "Wards",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
