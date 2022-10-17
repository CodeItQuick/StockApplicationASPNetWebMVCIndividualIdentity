using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class KeyMetricsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyMetrics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevenuePerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    NetIncomePerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    OperatingCashFlowPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    FreeCashFlowPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    CashPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    BookValuePerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    TangibleBookValuePerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    ShareholdersEquityPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    InterestDebtPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    MarketCap = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    EnterpriseValue = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PeRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PriceToSalesRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Pocfratio = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PfcfRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PbRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PtbRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    EvToSales = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    EnterpriseValueOverEbitda = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    EvToOperatingCashFlow = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    EvToFreeCashFlow = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    EarningsYield = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    FreeCashFlowYield = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DebtToEquity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DebtToAssets = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    NetDebtToEbitda = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    CurrentRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    InterestCoverage = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    IncomeQuality = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DividendYield = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    PayoutRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    SalesGeneralAndAdministrativeToRevenue = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    ResearchAndDdevelopementToRevenue = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    IntangiblesToTotalAssets = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    CapexToOperatingCashFlow = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    CapexToRevenue = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    CapexToDepreciation = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    StockBasedCompensationToRevenue = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    GrahamNumber = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Roic = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    ReturnOnTangibleAssets = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    GrahamNetNet = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    WorkingCapital = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    TangibleAssetValue = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    NetCurrentAssetValue = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    InvestedCapital = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    AverageReceivables = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    AveragePayables = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    AverageInventory = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    DaysSalesOutstanding = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DaysPayablesOutstanding = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DaysOfInventoryOnHand = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    ReceivablesTurnover = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PayablesTurnover = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    InventoryTurnover = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    Roe = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    CapexPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyMetrics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyMetrics");
        }
    }
}
