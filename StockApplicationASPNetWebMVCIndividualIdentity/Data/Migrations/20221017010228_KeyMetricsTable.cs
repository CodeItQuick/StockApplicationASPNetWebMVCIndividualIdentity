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
                    Symbol = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevenuePerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    NetIncomePerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    OperatingCashFlowPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    FreeCashFlowPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    CashPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    BookValuePerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    TangibleBookValuePerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    ShareholdersEquityPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    InterestDebtPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    MarketCap = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    EnterpriseValue = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    PeRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    PriceToSalesRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    Pocfratio = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    PfcfRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    PbRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    PtbRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    EvToSales = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    EnterpriseValueOverEbitda = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    EvToOperatingCashFlow = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    EvToFreeCashFlow = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    EarningsYield = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    FreeCashFlowYield = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    DebtToEquity = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    DebtToAssets = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    NetDebtToEbitda = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    CurrentRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    InterestCoverage = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    IncomeQuality = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    DividendYield = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    PayoutRatio = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    SalesGeneralAndAdministrativeToRevenue = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    ResearchAndDdevelopementToRevenue = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    IntangiblesToTotalAssets = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    CapexToOperatingCashFlow = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    CapexToRevenue = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    CapexToDepreciation = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    StockBasedCompensationToRevenue = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    GrahamNumber = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    Roic = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    ReturnOnTangibleAssets = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    GrahamNetNet = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    WorkingCapital = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    TangibleAssetValue = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    NetCurrentAssetValue = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    InvestedCapital = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    AverageReceivables = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    AveragePayables = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    AverageInventory = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    DaysSalesOutstanding = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    DaysPayablesOutstanding = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    DaysOfInventoryOnHand = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    ReceivablesTurnover = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    PayablesTurnover = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    InventoryTurnover = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    Roe = table.Column<decimal>(type: "decimal(18,5)", nullable: true),
                    CapexPerShare = table.Column<decimal>(type: "decimal(18,5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyMetrics", x => x.Id);
                    table.UniqueConstraint("UK_KeyMetrics_Symbol_Date", x => new {x.Symbol, x.Date});
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyMetrics");
        }
    }
}
