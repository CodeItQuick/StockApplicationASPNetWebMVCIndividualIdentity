using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class dummy_migration_two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StockInfoDatumDTOId",
                table: "CashFlowStatement",
                type: "bigint",
                nullable: true,
                defaultValue: null);
            migrationBuilder.CreateIndex(
                name: "IX_CashFlowStatement_StockInfoDatumDTOId",
                table: "CashFlowStatement",
                column: "StockInfoDatumDTOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CashFlowStatement_StockInfoDatumDTOId",
                table: "CashFlowStatement");
        }
    }
}
