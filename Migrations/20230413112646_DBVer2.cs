using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseBurgerWeb.Migrations
{
    /// <inheritdoc />
    public partial class DBVer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admins_accounts_AccountID",
                table: "admins");

            migrationBuilder.DropForeignKey(
                name: "FK_admins_roles_RoleID",
                table: "admins");

            migrationBuilder.DropForeignKey(
                name: "FK_customers_accounts_AccountID",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                table: "accounts");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "admins",
                newName: "Admins");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_customers_AccountID",
                table: "Customers",
                newName: "IX_Customers_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_admins_RoleID",
                table: "Admins",
                newName: "IX_Admins_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_admins_AccountID",
                table: "Admins",
                newName: "IX_Admins_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Accounts_AccountID",
                table: "Admins",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Roles_RoleID",
                table: "Admins",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountID",
                table: "Customers",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Accounts_AccountID",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Roles_RoleID",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountID",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customers");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "admins");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_AccountID",
                table: "customers",
                newName: "IX_customers_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_RoleID",
                table: "admins",
                newName: "IX_admins_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_AccountID",
                table: "admins",
                newName: "IX_admins_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                table: "accounts",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_admins_accounts_AccountID",
                table: "admins",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_admins_roles_RoleID",
                table: "admins",
                column: "RoleID",
                principalTable: "roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customers_accounts_AccountID",
                table: "customers",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
