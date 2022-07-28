using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asseco_pfm.Migrations
{
    public partial class SubCategoryImpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentCategoryC",
                table: "category",
                newName: "ParentCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentCategory",
                table: "category",
                newName: "ParentCategoryC");
        }
    }
}
