using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asseco_pfm.Migrations
{
    public partial class AddTransactionForeignKeyCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_transaction_Catcode",
                table: "transaction",
                column: "Catcode");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_category_Catcode",
                table: "transaction",
                column: "Catcode",
                principalTable: "category",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_category_Catcode",
                table: "transaction");

            migrationBuilder.DropIndex(
                name: "IX_transaction_Catcode",
                table: "transaction");
        }
    }
}
