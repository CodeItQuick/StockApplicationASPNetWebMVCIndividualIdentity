using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;

[Table("KeyMetrics")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class KeyMetricsDto : DatabaseTable
{
    [Key]
    [JsonProperty(PropertyName = "Id")]
    public override long Id { get; set; }
    [JsonProperty(PropertyName = "Symbol")]
    public string Symbol { get; set; }
    [JsonProperty(PropertyName = "Date")]
    public DateTimeOffset Date { get; set; }
    [JsonProperty(PropertyName = "Period")]
    public string Period { get; set; }
    [JsonProperty(PropertyName = "RevenuePerShare")]
    public decimal? RevenuePerShare { get; set; }
    [JsonProperty(PropertyName = "NetIncomePerShare")]
    public decimal? NetIncomePerShare { get; set; }
    [JsonProperty(PropertyName = "OperatingCashFlowPerShare")]
    public decimal? OperatingCashFlowPerShare { get; set; }
    [JsonProperty(PropertyName = "FreeCashFlowPerShare")]
    public decimal? FreeCashFlowPerShare { get; set; }
    [JsonProperty(PropertyName = "CashPerShare")]
    public decimal? CashPerShare { get; set; }
    [JsonProperty(PropertyName = "BookValuePerShare")]
    public decimal? BookValuePerShare { get; set; }
    [JsonProperty(PropertyName = "TangibleBookValuePerShare")]
    public decimal? TangibleBookValuePerShare { get; set; }
    [JsonProperty(PropertyName = "ShareholdersEquityPerShare")]
    public decimal? ShareholdersEquityPerShare { get; set; }
    [JsonProperty(PropertyName = "InterestDebtPerShare")]
    public decimal? InterestDebtPerShare { get; set; }
    [JsonProperty(PropertyName = "MarketCap")]
    public decimal? MarketCap { get; set; }
    [JsonProperty(PropertyName = "EnterpriseValue")]
    public decimal? EnterpriseValue { get; set; }
    [JsonProperty(PropertyName = "PeRatio")]
    public decimal? PeRatio { get; set; }
    [JsonProperty(PropertyName = "PriceToSalesRatio")]
    public decimal? PriceToSalesRatio { get; set; }
    [JsonProperty(PropertyName = "Pocfratio")]
    public decimal? Pocfratio { get; set; }
    [JsonProperty(PropertyName = "PfcfRatio")]
    public decimal? PfcfRatio { get; set; }
    [JsonProperty(PropertyName = "PbRatio")]
    public decimal? PbRatio { get; set; }
    [JsonProperty(PropertyName = "PtbRatio")]
    public decimal? PtbRatio { get; set; }
    [JsonProperty(PropertyName = "EvToSales")]
    public decimal? EvToSales { get; set; }
    [JsonProperty(PropertyName = "EnterpriseValueOverEbitda")]
    public decimal? EnterpriseValueOverEbitda { get; set; }
    [JsonProperty(PropertyName = "EvToOperatingCashFlow")]
    public decimal? EvToOperatingCashFlow { get; set; }
    [JsonProperty(PropertyName = "EvToFreeCashFlow")]
    public decimal? EvToFreeCashFlow { get; set; }
    [JsonProperty(PropertyName = "EarningsYield")]
    public decimal? EarningsYield { get; set; }
    [JsonProperty(PropertyName = "FreeCashFlowYield")]
    public decimal? FreeCashFlowYield { get; set; }
    [JsonProperty(PropertyName = "DebtToEquity")]
    public decimal? DebtToEquity { get; set; }
    [JsonProperty(PropertyName = "DebtToAssets")]
    public decimal? DebtToAssets { get; set; }
    [JsonProperty(PropertyName = "NetDebtToEbitda")]
    public decimal? NetDebtToEbitda { get; set; }
    [JsonProperty(PropertyName = "CurrentRatio")]
    public decimal? CurrentRatio { get; set; }
    [JsonProperty(PropertyName = "InterestCoverage")]
    public decimal? InterestCoverage { get; set; }
    [JsonProperty(PropertyName = "IncomeQuality")]
    public decimal? IncomeQuality { get; set; }
    [JsonProperty(PropertyName = "DividendYield")]
    public decimal? DividendYield { get; set; }
    [JsonProperty(PropertyName = "PayoutRatio")]
    public decimal? PayoutRatio { get; set; }
    [JsonProperty(PropertyName = "SalesGeneralAndAdministrativeToRevenue")]
    public decimal? SalesGeneralAndAdministrativeToRevenue { get; set; }
    [JsonProperty(PropertyName = "ResearchAndDdevelopementToRevenue")]
    public decimal? ResearchAndDdevelopementToRevenue { get; set; }
    [JsonProperty(PropertyName = "IntangiblesToTotalAssets")]
    public decimal? IntangiblesToTotalAssets { get; set; }
    [JsonProperty(PropertyName = "CapexToOperatingCashFlow")]
    public decimal? CapexToOperatingCashFlow { get; set; }
    [JsonProperty(PropertyName = "CapexToRevenue")]
    public decimal? CapexToRevenue { get; set; }
    [JsonProperty(PropertyName = "CapexToDepreciation")]
    public decimal? CapexToDepreciation { get; set; }
    [JsonProperty(PropertyName = "StockBasedCompensationToRevenue")]
    public decimal? StockBasedCompensationToRevenue { get; set; }
    [JsonProperty(PropertyName = "GrahamNumber")]
    public decimal? GrahamNumber { get; set; }
    [JsonProperty(PropertyName = "Roic")]
    public decimal? Roic { get; set; }
    [JsonProperty(PropertyName = "ReturnOnTangibleAssets")]
    public decimal? ReturnOnTangibleAssets { get; set; }
    [JsonProperty(PropertyName = "GrahamNetNet")]
    public decimal? GrahamNetNet { get; set; }
    [JsonProperty(PropertyName = "WorkingCapital")]
    public decimal? WorkingCapital { get; set; }
    [JsonProperty(PropertyName = "TangibleAssetValue")]
    public decimal? TangibleAssetValue { get; set; }
    [JsonProperty(PropertyName = "NetCurrentAssetValue")]
    public decimal? NetCurrentAssetValue { get; set; }
    [JsonProperty(PropertyName = "InvestedCapital")]
    public decimal? InvestedCapital { get; set; }
    [JsonProperty(PropertyName = "AverageReceivables")]
    public decimal? AverageReceivables { get; set; }
    [JsonProperty(PropertyName = "AveragePayables")]
    public decimal? AveragePayables { get; set; }
    [JsonProperty(PropertyName = "AverageInventory")]
    public decimal? AverageInventory { get; set; }
    [JsonProperty(PropertyName = "DaysSalesOutstanding")]
    public decimal? DaysSalesOutstanding { get; set; }
    [JsonProperty(PropertyName = "DaysPayablesOutstanding")]
    public decimal? DaysPayablesOutstanding { get; set; }
    [JsonProperty(PropertyName = "DaysOfInventoryOnHand")]
    public decimal? DaysOfInventoryOnHand { get; set; }
    [JsonProperty(PropertyName = "ReceivablesTurnover")]
    public decimal? ReceivablesTurnover { get; set; }
    [JsonProperty(PropertyName = "PayablesTurnover")]
    public decimal? PayablesTurnover { get; set; }
    [JsonProperty(PropertyName = "InventoryTurnover")]
    public decimal? InventoryTurnover { get; set; }
    [JsonProperty(PropertyName = "Roe")]
    public decimal? Roe { get; set; }
    [JsonProperty(PropertyName = "CapexPerShare")]
    public decimal? CapexPerShare { get; set; }
}

