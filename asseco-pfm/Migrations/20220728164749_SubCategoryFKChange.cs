using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asseco_pfm.Migrations
{
    public partial class SubCategoryFKChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_category_ParentCode",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_category_ParentCode",
                table: "category");

            migrationBuilder.CreateIndex(
                name: "IX_category_ParentCategory",
                table: "category",
                column: "ParentCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_category_category_ParentCategory",
                table: "category",
                column: "ParentCategory",
                principalTable: "category",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_category_ParentCategory",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_category_ParentCategory",
                table: "category");

            migrationBuilder.CreateIndex(
                name: "IX_category_ParentCode",
                table: "category",
                column: "ParentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_category_category_ParentCode",
                table: "category",
                column: "ParentCode",
                principalTable: "category",
                principalColumn: "Code");
        }
    }
}
