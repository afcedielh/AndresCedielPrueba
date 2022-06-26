using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Data.Migrations
{
    public partial class CreateCatalogDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Categories_CategoryId",
                table: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Catalogs_CategoryId",
                table: "Catalogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_CategoryId",
                table: "Catalogs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Categories_CategoryId",
                table: "Catalogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
