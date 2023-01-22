using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

[Table("Ratios")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class RatiosDto : DatabaseTable
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
    [JsonProperty(PropertyName = "CurrentRatio")]
    public decimal? CurrentRatio { get; set; }
    [JsonProperty(PropertyName = "QuickRatio")]
    public decimal? QuickRatio { get; set; }
    [JsonProperty(PropertyName = "CashRatio")]
    public decimal? CashRatio { get; set; }
    [JsonProperty(PropertyName = "DaysOfSalesOutstanding")]
    public decimal? DaysOfSalesOutstanding { get; set; }
    [JsonProperty(PropertyName = "DaysOfInventoryOutstanding")]
    public decimal? DaysOfInventoryOutstanding { get; set; }
    [JsonProperty(PropertyName = "OperatingCycle")]
    public decimal? OperatingCycle { get; set; }
    [JsonProperty(PropertyName = "DaysOfPayablesOutstanding")]
    public decimal? DaysOfPayablesOutstanding { get; set; }
    [JsonProperty(PropertyName = "CashConversionCycle")]
    public decimal? CashConversionCycle { get; set; }
    [JsonProperty(PropertyName = "GrossProfitMargin")]
    public decimal? GrossProfitMargin { get; set; }
    [JsonProperty(PropertyName = "OperatingProfitMargin")]
    public decimal? OperatingProfitMargin { get; set; }
    [JsonProperty(PropertyName = "PretaxProfitMargin")]
    public decimal? PretaxProfitMargin { get; set; }
    [JsonProperty(PropertyName = "NetProfitMargin")]
    public decimal? NetProfitMargin { get; set; }
    [JsonProperty(PropertyName = "EffectiveTaxRate")]
    public decimal? EffectiveTaxRate { get; set; }
    [JsonProperty(PropertyName = "ReturnOnAssets")]
    public decimal? ReturnOnAssets { get; set; }
    [JsonProperty(PropertyName = "ReturnOnEquity")]
    public decimal? ReturnOnEquity { get; set; }
    [JsonProperty(PropertyName = "ReturnOnCapitalEmployed")]
    public decimal? ReturnOnCapitalEmployed { get; set; }
    [JsonProperty(PropertyName = "NetIncomePerEbt")]
    public decimal? NetIncomePerEbt { get; set; }
    [JsonProperty(PropertyName = "EbtPerEbit")]
    public decimal? EbtPerEbit { get; set; }
    [JsonProperty(PropertyName = "EbitPerRevenue")]
    public decimal? EbitPerRevenue { get; set; }
    [JsonProperty(PropertyName = "DebtRatio")]
    public decimal? DebtRatio { get; set; }
    [JsonProperty(PropertyName = "DebtEquityRatio")]
    public decimal? DebtEquityRatio { get; set; }
    [JsonProperty(PropertyName = "LongTermDebtToCapitalization")]
    public decimal? LongTermDebtToCapitalization { get; set; }
    [JsonProperty(PropertyName = "TotalDebtToCapitalization")]
    public decimal? TotalDebtToCapitalization { get; set; }
    [JsonProperty(PropertyName = "InterestCoverage")]
    public decimal? InterestCoverage { get; set; }
    [JsonProperty(PropertyName = "CashFlowToDebtRatio")]
    public decimal? CashFlowToDebtRatio { get; set; }
    [JsonProperty(PropertyName = "CompanyEquityMultiplier")]
    public decimal? CompanyEquityMultiplier { get; set; }
    [JsonProperty(PropertyName = "ReceivablesTurnover")]
    public decimal? ReceivablesTurnover { get; set; }
    [JsonProperty(PropertyName = "PayablesTurnover")]
    public decimal? PayablesTurnover { get; set; }
    [JsonProperty(PropertyName = "InventoryTurnover")]
    public decimal? InventoryTurnover { get; set; }
    [JsonProperty(PropertyName = "FixedAssetTurnover")]
    public decimal? FixedAssetTurnover { get; set; }
    [JsonProperty(PropertyName = "AssetTurnover")]
    public decimal? AssetTurnover { get; set; }
    [JsonProperty(PropertyName = "OperatingCashFlowPerShare")]
    public decimal? OperatingCashFlowPerShare { get; set; }
    [JsonProperty(PropertyName = "FreeCashFlowPerShare")]
    public decimal? FreeCashFlowPerShare { get; set; }
    [JsonProperty(PropertyName = "CashPerShare")]
    public decimal? CashPerShare { get; set; }
    [JsonProperty(PropertyName = "PayoutRatio")]
    public decimal? PayoutRatio { get; set; }
    [JsonProperty(PropertyName = "OperatingCashFlowSalesRatio")]
    public decimal? OperatingCashFlowSalesRatio { get; set; }
    [JsonProperty(PropertyName = "FreeCashFlowOperatingCashFlowRatio")]
    public decimal? FreeCashFlowOperatingCashFlowRatio { get; set; }
    [JsonProperty(PropertyName = "CashFlowCoverageRatios")]
    public decimal? CashFlowCoverageRatios { get; set; }
    [JsonProperty(PropertyName = "ShortTermCoverageRatios")]
    public decimal? ShortTermCoverageRatios { get; set; }
    [JsonProperty(PropertyName = "CapitalExpenditureCoverageRatio")]
    public decimal? CapitalExpenditureCoverageRatio { get; set; }
    [JsonProperty(PropertyName = "DividendPaidAndCapexCoverageRatio")]
    public decimal? DividendPaidAndCapexCoverageRatio { get; set; }
    [JsonProperty(PropertyName = "DividendPayoutRatio")]
    public decimal? DividendPayoutRatio { get; set; }
    [JsonProperty(PropertyName = "PriceBookValueRatio")]
    public decimal? PriceBookValueRatio { get; set; }
    [JsonProperty(PropertyName = "PriceToBookRatio")]
    public decimal? PriceToBookRatio { get; set; }
    [JsonProperty(PropertyName = "PriceToSalesRatio")]
    public decimal? PriceToSalesRatio { get; set; }
    [JsonProperty(PropertyName = "PriceEarningsRatio")]
    public decimal? PriceEarningsRatio { get; set; }
    [JsonProperty(PropertyName = "PriceToFreeCashFlowsRatio")]
    public decimal? PriceToFreeCashFlowsRatio { get; set; }
    [JsonProperty(PropertyName = "PriceToOperatingCashFlowsRatio")]
    public decimal? PriceToOperatingCashFlowsRatio { get; set; }
    [JsonProperty(PropertyName = "PriceCashFlowRatio")]
    public decimal? PriceCashFlowRatio { get; set; }
    [JsonProperty(PropertyName = "PriceEarningsToGrowthRatio")]
    public decimal? PriceEarningsToGrowthRatio { get; set; }
    [JsonProperty(PropertyName = "PriceSalesRatio")]
    public decimal? PriceSalesRatio { get; set; }
    [JsonProperty(PropertyName = "DividendYield")]
    public decimal? DividendYield { get; set; }
    [JsonProperty(PropertyName = "EnterpriseValueMultiple")]
    public decimal? EnterpriseValueMultiple { get; set; }
    [JsonProperty(PropertyName = "PriceFairValue")]
    public decimal? PriceFairValue { get; set; }
}