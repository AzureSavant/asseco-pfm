using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asseco_pfm.Migrations
{
    public partial class linkTransactionSplitTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactionsplit_transaction_TransactionId",
                table: "transactionsplit");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "transactionsplit",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_transactionsplit_transaction_TransactionId",
                table: "transactionsplit",
                column: "TransactionId",
                principalTable: "transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactionsplit_transaction_TransactionId",
                table: "transactionsplit");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "transactionsplit",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_transactionsplit_transaction_TransactionId",
                table: "transactionsplit",
                column: "TransactionId",
                principalTable: "transaction",
                principalColumn: "Id");
        }
    }
}
