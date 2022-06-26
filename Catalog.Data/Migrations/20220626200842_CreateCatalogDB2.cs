using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Data.Migrations
{
    public partial class CreateCatalogDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Categories_CatalogCategoryCategoryId",
                table: "Catalogs");

            migrationBuilder.RenameColumn(
                name: "CatalogCategoryCategoryId",
                table: "Catalogs",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogs_CatalogCategoryCategoryId",
                table: "Catalogs",
                newName: "IX_Catalogs_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Categories_CategoryId",
                table: "Catalogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Categories_CategoryId",
                table: "Catalogs");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Catalogs",
                newName: "CatalogCategoryCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogs_CategoryId",
                table: "Catalogs",
                newName: "IX_Catalogs_CatalogCategoryCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Categories_CatalogCategoryCategoryId",
                table: "Catalogs",
                column: "CatalogCategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
