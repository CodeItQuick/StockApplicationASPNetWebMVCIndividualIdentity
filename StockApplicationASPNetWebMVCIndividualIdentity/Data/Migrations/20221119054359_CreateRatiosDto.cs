using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class CreateRatiosDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetTurnoverTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CapitalExpenditureCoverageRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashConversionCycleTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashFlowCoverageRatiosTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashFlowToDebtRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashPerShareTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CompanyEquityMultiplierTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CurrentRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DaysOfInventoryOutstandingTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DaysOfPayablesOutstandingTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DaysOfSalesOutstandingTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DebtEquityRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DebtRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DividendPaidAndCapexCoverageRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DividendPerShareTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DividendYielPercentageTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DividendYielTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DividendYieldTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "EbitPerRevenueTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "EbtPerEbitTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "EffectiveTaxRateTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "EnterpriseValueMultipleTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "FixedAssetTurnoverTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "FreeCashFlowOperatingCashFlowRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "FreeCashFlowPerShareTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "GrossProfitMarginTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "InterestCoverageTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "InventoryTurnoverTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "LongTermDebtToCapitalizationTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "NetIncomePerEbtttm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "NetProfitMarginTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "OperatingCashFlowPerShareTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "OperatingCashFlowSalesRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "OperatingCycleTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "OperatingProfitMarginTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PayablesTurnoverTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PayoutRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PeRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PegRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PretaxProfitMarginTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceBookValueRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceCashFlowRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceEarningsRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceEarningsToGrowthRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceFairValueTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceSalesRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceToBookRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceToFreeCashFlowsRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceToOperatingCashFlowsRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceToSalesRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "QuickRatioTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ReceivablesTurnoverTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ReturnOnAssetsTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ReturnOnCapitalEmployedTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ReturnOnEquityTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ShortTermCoverageRatiosTtm",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "TotalDebtToCapitalizationTtm",
                table: "RatiosTTM");
            
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "RatiosTTM");

            migrationBuilder.AddColumn<decimal>(
                name: "AssetTurnover",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CapitalExpenditureCoverageRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CashConversionCycle",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CashFlowCoverageRatios",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CashFlowToDebtRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CashPerShare",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CashRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CompanyEquityMultiplier",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "RatiosTTM",
                type: "datetimeoffset",
                nullable: true,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<decimal>(
                name: "DaysOfInventoryOutstanding",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DaysOfPayablesOutstanding",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DaysOfSalesOutstanding",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DebtEquityRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DebtRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendPaidAndCapexCoverageRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendPayoutRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendYield",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EbitPerRevenue",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EbtPerEbit",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EffectiveTaxRate",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EnterpriseValueMultiple",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FixedAssetTurnover",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FreeCashFlowOperatingCashFlowRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FreeCashFlowPerShare",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossProfitMargin",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestCoverage",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InventoryTurnover",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LongTermDebtToCapitalization",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetIncomePerEbt",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetProfitMargin",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatingCashFlowPerShare",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatingCashFlowSalesRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatingCycle",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatingProfitMargin",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PayablesTurnover",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PayoutRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "RatiosTTM",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PretaxProfitMargin",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceBookValueRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceCashFlowRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceEarningsRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceEarningsToGrowthRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceFairValue",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceSalesRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceToBookRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceToFreeCashFlowsRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceToOperatingCashFlowsRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceToSalesRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QuickRatio",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivablesTurnover",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnOnAssets",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnOnCapitalEmployed",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnOnEquity",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ShortTermCoverageRatios",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "RatiosTTM",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDebtToCapitalization",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetTurnover",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CapitalExpenditureCoverageRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashConversionCycle",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashFlowCoverageRatios",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashFlowToDebtRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashPerShare",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CashRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CompanyEquityMultiplier",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "CurrentRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DaysOfInventoryOutstanding",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DaysOfPayablesOutstanding",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DaysOfSalesOutstanding",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DebtEquityRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DebtRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DividendPaidAndCapexCoverageRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DividendPayoutRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "DividendYield",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "EbitPerRevenue",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "EbtPerEbit",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "EffectiveTaxRate",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "EnterpriseValueMultiple",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "FixedAssetTurnover",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "FreeCashFlowOperatingCashFlowRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "FreeCashFlowPerShare",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "GrossProfitMargin",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "InterestCoverage",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "InventoryTurnover",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "LongTermDebtToCapitalization",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "NetIncomePerEbt",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "NetProfitMargin",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "OperatingCashFlowPerShare",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "OperatingCashFlowSalesRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "OperatingCycle",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "OperatingProfitMargin",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PayablesTurnover",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PayoutRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PretaxProfitMargin",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceBookValueRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceCashFlowRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceEarningsRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceEarningsToGrowthRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceFairValue",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceSalesRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceToBookRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceToFreeCashFlowsRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceToOperatingCashFlowsRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "PriceToSalesRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "QuickRatio",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ReceivablesTurnover",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ReturnOnAssets",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ReturnOnCapitalEmployed",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ReturnOnEquity",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "ShortTermCoverageRatios",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "RatiosTTM");

            migrationBuilder.DropColumn(
                name: "TotalDebtToCapitalization",
                table: "RatiosTTM");

            migrationBuilder.AddColumn<decimal>(
                name: "AssetTurnoverTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CapitalExpenditureCoverageRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashConversionCycleTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashFlowCoverageRatiosTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashFlowToDebtRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashPerShareTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CompanyEquityMultiplierTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DaysOfInventoryOutstandingTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DaysOfPayablesOutstandingTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DaysOfSalesOutstandingTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DebtEquityRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DebtRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendPaidAndCapexCoverageRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendPerShareTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendYielPercentageTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendYielTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendYieldTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EbitPerRevenueTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EbtPerEbitTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EffectiveTaxRateTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EnterpriseValueMultipleTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FixedAssetTurnoverTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FreeCashFlowOperatingCashFlowRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FreeCashFlowPerShareTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossProfitMarginTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestCoverageTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InventoryTurnoverTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LongTermDebtToCapitalizationTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetIncomePerEbtttm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetProfitMarginTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatingCashFlowPerShareTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatingCashFlowSalesRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatingCycleTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OperatingProfitMarginTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PayablesTurnoverTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PayoutRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PeRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PegRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PretaxProfitMarginTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceBookValueRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceCashFlowRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceEarningsRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceEarningsToGrowthRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceFairValueTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceSalesRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceToBookRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceToFreeCashFlowsRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceToOperatingCashFlowsRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceToSalesRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "QuickRatioTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivablesTurnoverTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnOnAssetsTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnOnCapitalEmployedTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnOnEquityTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShortTermCoverageRatiosTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDebtToCapitalizationTtm",
                table: "RatiosTTM",
                type: "decimal(18,4)",
                nullable: true);
        }
    }
}
