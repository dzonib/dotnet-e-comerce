using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data
{
    /// <inheritdoc />
    public partial class RenamedProductBrandsToProductBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsBrands_ProductBrandId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsBrands",
                table: "ProductsBrands");

            migrationBuilder.RenameTable(
                name: "ProductsBrands",
                newName: "ProductBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands");

            migrationBuilder.RenameTable(
                name: "ProductBrands",
                newName: "ProductsBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsBrands",
                table: "ProductsBrands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsBrands_ProductBrandId",
                table: "Products",
                column: "ProductBrandId",
                principalTable: "ProductsBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
