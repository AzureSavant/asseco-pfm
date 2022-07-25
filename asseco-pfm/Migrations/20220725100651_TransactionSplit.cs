using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace asseco_pfm.Migrations
{
    public partial class TransactionSplit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactionsplit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CatCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionsplit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactionsplit_transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "transaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactionsplit_TransactionId",
                table: "transactionsplit",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactionsplit");
        }
    }
}
