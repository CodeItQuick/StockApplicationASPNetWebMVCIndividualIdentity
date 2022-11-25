using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class CreateRatiosTtmTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WorkingCapital",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TangibleBookValuePerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "StockBasedCompensationToRevenue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ShareholdersEquityPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesGeneralAndAdministrativeToRevenue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Roic",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Roe",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RevenuePerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnOnTangibleAssets",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ResearchAndDdevelopementToRevenue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReceivablesTurnover",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PtbRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceToSalesRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pocfratio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PfcfRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PeRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PbRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PayoutRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PayablesTurnover",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OperatingCashFlowPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetIncomePerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetDebtToEbitda",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetCurrentAssetValue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MarketCap",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "InvestedCapital",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestDebtPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IntangiblesToTotalAssets",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IncomeQuality",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GrahamNumber",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GrahamNetNet",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FreeCashFlowYield",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FreeCashFlowPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EvToSales",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EvToOperatingCashFlow",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EvToFreeCashFlow",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EnterpriseValueOverEbitda",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EnterpriseValue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EarningsYield",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DebtToEquity",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DebtToAssets",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DaysSalesOutstanding",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DaysPayablesOutstanding",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DaysOfInventoryOnHand",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CapexToRevenue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CapexToOperatingCashFlow",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CapexPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BookValuePerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageReceivables",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AveragePayables",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.CreateTable(
                name: "RatiosTTM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DividendYielTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    DividendYielPercentageTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PeRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PegRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PayoutRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CurrentRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    QuickRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CashRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DaysOfSalesOutstandingTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DaysOfInventoryOutstandingTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    OperatingCycleTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DaysOfPayablesOutstandingTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CashConversionCycleTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    GrossProfitMarginTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    OperatingProfitMarginTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PretaxProfitMarginTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    NetProfitMarginTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    EffectiveTaxRateTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ReturnOnAssetsTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ReturnOnEquityTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ReturnOnCapitalEmployedTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    NetIncomePerEbtttm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    EbtPerEbitTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    EbitPerRevenueTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DebtRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DebtEquityRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    LongTermDebtToCapitalizationTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    TotalDebtToCapitalizationTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    InterestCoverageTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CashFlowToDebtRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CompanyEquityMultiplierTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ReceivablesTurnoverTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PayablesTurnoverTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    InventoryTurnoverTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FixedAssetTurnoverTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    AssetTurnoverTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    OperatingCashFlowPerShareTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FreeCashFlowPerShareTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CashPerShareTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    OperatingCashFlowSalesRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FreeCashFlowOperatingCashFlowRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CashFlowCoverageRatiosTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ShortTermCoverageRatiosTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CapitalExpenditureCoverageRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DividendPaidAndCapexCoverageRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceBookValueRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceToBookRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceToSalesRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceEarningsRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceToFreeCashFlowsRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceToOperatingCashFlowsRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceCashFlowRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceEarningsToGrowthRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceSalesRatioTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DividendYieldTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    EnterpriseValueMultipleTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PriceFairValueTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DividendPerShareTtm = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatiosTTM", x => x.Id);
                    // table.UniqueConstraint("UK_RatiosTTM_Symbol", x => x.Symbol);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatiosTTM");

            migrationBuilder.AlterColumn<decimal>(
                name: "WorkingCapital",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TangibleBookValuePerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "StockBasedCompensationToRevenue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ShareholdersEquityPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesGeneralAndAdministrativeToRevenue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Roic",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Roe",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RevenuePerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnOnTangibleAssets",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ResearchAndDdevelopementToRevenue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReceivablesTurnover",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PtbRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceToSalesRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Pocfratio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PfcfRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PeRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PbRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PayoutRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PayablesTurnover",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OperatingCashFlowPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetIncomePerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetDebtToEbitda",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetCurrentAssetValue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MarketCap",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InvestedCapital",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestDebtPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IntangiblesToTotalAssets",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IncomeQuality",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrahamNumber",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrahamNetNet",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FreeCashFlowYield",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FreeCashFlowPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EvToSales",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EvToOperatingCashFlow",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EvToFreeCashFlow",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EnterpriseValueOverEbitda",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EnterpriseValue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EarningsYield",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DebtToEquity",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DebtToAssets",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DaysSalesOutstanding",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DaysPayablesOutstanding",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DaysOfInventoryOnHand",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentRatio",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CashPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CapexToRevenue",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CapexToOperatingCashFlow",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CapexPerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BookValuePerShare",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageReceivables",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AveragePayables",
                table: "KeyMetrics",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);
        }
    }
}
