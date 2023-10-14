using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class ProductCategoryWithModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductCategory_ProductCategories_CategoriesId",
                table: "ProductProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductCategory_Products_ProductsId",
                table: "ProductProductCategory");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductProductCategory",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "ProductProductCategory",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProductCategory_ProductsId",
                table: "ProductProductCategory",
                newName: "IX_ProductProductCategory_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductCategory_Categories",
                table: "ProductProductCategory",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductCategory_Products",
                table: "ProductProductCategory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductCategory_Categories",
                table: "ProductProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductCategory_Products",
                table: "ProductProductCategory");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductProductCategory",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductProductCategory",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProductCategory_ProductId",
                table: "ProductProductCategory",
                newName: "IX_ProductProductCategory_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductCategory_ProductCategories_CategoriesId",
                table: "ProductProductCategory",
                column: "CategoriesId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductCategory_Products_ProductsId",
                table: "ProductProductCategory",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
