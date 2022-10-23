using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

[Table("RatiosTTM")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class RatiosTtmDto
{
    [Key]
    [JsonProperty(PropertyName = "Id")]
    public int Id { get; set; }
    [JsonProperty(PropertyName = "DividendYielTtm")]
    public decimal? DividendYielTtm { get; set; }
    
    [JsonProperty(PropertyName = "DividendYielPercentageTtm")]
    public decimal? DividendYielPercentageTtm { get; set; }
    
    [JsonProperty(PropertyName = "PeRatioTtm")]
    public decimal? PeRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PegRatioTtm")]
    public decimal? PegRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PayoutRatioTtm")]
    public decimal? PayoutRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "CurrentRatioTtm")]
    public decimal? CurrentRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "QuickRatioTtm")]
    public decimal? QuickRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "CashRatioTtm")]
    public decimal? CashRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "DaysOfSalesOutstandingTtm")]
    public decimal? DaysOfSalesOutstandingTtm { get; set; }
    
    [JsonProperty(PropertyName = "DaysOfInventoryOutstandingTtm")]
    public decimal? DaysOfInventoryOutstandingTtm { get; set; }
    
    [JsonProperty(PropertyName = "OperatingCycleTtm")]
    public decimal? OperatingCycleTtm { get; set; }
    
    [JsonProperty(PropertyName = "DaysOfPayablesOutstandingTtm")]
    public decimal? DaysOfPayablesOutstandingTtm { get; set; }
    
    [JsonProperty(PropertyName = "CashConversionCycleTtm")]
    public decimal? CashConversionCycleTtm { get; set; }
    
    [JsonProperty(PropertyName = "GrossProfitMarginTtm")]
    public decimal? GrossProfitMarginTtm { get; set; }
    
    [JsonProperty(PropertyName = "OperatingProfitMarginTtm")]
    public decimal? OperatingProfitMarginTtm { get; set; }
    
    [JsonProperty(PropertyName = "PretaxProfitMarginTtm")]
    public decimal? PretaxProfitMarginTtm { get; set; }
    
    [JsonProperty(PropertyName = "NetProfitMarginTtm")]
    public decimal? NetProfitMarginTtm { get; set; }
    
    [JsonProperty(PropertyName = "EffectiveTaxRateTtm")]
    public decimal? EffectiveTaxRateTtm { get; set; }
    
    [JsonProperty(PropertyName = "ReturnOnAssetsTtm")]
    public decimal? ReturnOnAssetsTtm { get; set; }
    
    [JsonProperty(PropertyName = "ReturnOnEquityTtm")]
    public decimal? ReturnOnEquityTtm { get; set; }
    
    [JsonProperty(PropertyName = "ReturnOnCapitalEmployedTtm")]
    public decimal? ReturnOnCapitalEmployedTtm { get; set; }
    
    [JsonProperty(PropertyName = "NetIncomePerEbtttm")]
    public decimal? NetIncomePerEbtttm { get; set; }
    
    [JsonProperty(PropertyName = "EbtPerEbitTtm")]
    public decimal? EbtPerEbitTtm { get; set; }
    
    [JsonProperty(PropertyName = "EbitPerRevenueTtm")]
    public decimal? EbitPerRevenueTtm { get; set; }
    
    [JsonProperty(PropertyName = "DebtRatioTtm")]
    public decimal? DebtRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "DebtEquityRatioTtm")]
    public decimal? DebtEquityRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "LongTermDebtToCapitalizationTtm")]
    public decimal? LongTermDebtToCapitalizationTtm { get; set; }
    
    [JsonProperty(PropertyName = "TotalDebtToCapitalizationTtm")]
    public decimal? TotalDebtToCapitalizationTtm { get; set; }
    
    [JsonProperty(PropertyName = "InterestCoverageTtm")]
    public decimal? InterestCoverageTtm { get; set; }
    
    [JsonProperty(PropertyName = "CashFlowToDebtRatioTtm")]
    public decimal? CashFlowToDebtRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "CompanyEquityMultiplierTtm")]
    public decimal? CompanyEquityMultiplierTtm { get; set; }
    
    [JsonProperty(PropertyName = "ReceivablesTurnoverTtm")]
    public decimal? ReceivablesTurnoverTtm { get; set; }
    
    [JsonProperty(PropertyName = "PayablesTurnoverTtm")]
    public decimal? PayablesTurnoverTtm { get; set; }
    
    [JsonProperty(PropertyName = "InventoryTurnoverTtm")]
    public decimal? InventoryTurnoverTtm { get; set; }
    
    [JsonProperty(PropertyName = "FixedAssetTurnoverTtm")]
    public decimal? FixedAssetTurnoverTtm { get; set; }
    
    [JsonProperty(PropertyName = "AssetTurnoverTtm")]
    public decimal? AssetTurnoverTtm { get; set; }
    
    [JsonProperty(PropertyName = "OperatingCashFlowPerShareTtm")]
    public decimal? OperatingCashFlowPerShareTtm { get; set; }
    
    [JsonProperty(PropertyName = "FreeCashFlowPerShareTtm")]
    public decimal? FreeCashFlowPerShareTtm { get; set; }
    
    [JsonProperty(PropertyName = "CashPerShareTtm")]
    public decimal? CashPerShareTtm { get; set; }
    
    [JsonProperty(PropertyName = "OperatingCashFlowSalesRatioTtm")]
    public decimal? OperatingCashFlowSalesRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "FreeCashFlowOperatingCashFlowRatioTtm")]
    public decimal? FreeCashFlowOperatingCashFlowRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "CashFlowCoverageRatiosTtm")]
    public decimal? CashFlowCoverageRatiosTtm { get; set; }
    
    [JsonProperty(PropertyName = "ShortTermCoverageRatiosTtm")]
    public decimal? ShortTermCoverageRatiosTtm { get; set; }
    
    [JsonProperty(PropertyName = "CapitalExpenditureCoverageRatioTtm")]
    public decimal? CapitalExpenditureCoverageRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "DividendPaidAndCapexCoverageRatioTtm")]
    public decimal? DividendPaidAndCapexCoverageRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceBookValueRatioTtm")]
    public decimal? PriceBookValueRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceToBookRatioTtm")]
    public decimal? PriceToBookRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceToSalesRatioTtm")]
    public decimal? PriceToSalesRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceEarningsRatioTtm")]
    public decimal? PriceEarningsRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceToFreeCashFlowsRatioTtm")]
    public decimal? PriceToFreeCashFlowsRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceToOperatingCashFlowsRatioTtm")]
    public decimal? PriceToOperatingCashFlowsRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceCashFlowRatioTtm")]
    public decimal? PriceCashFlowRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceEarningsToGrowthRatioTtm")]
    public decimal? PriceEarningsToGrowthRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceSalesRatioTtm")]
    public decimal? PriceSalesRatioTtm { get; set; }
    
    [JsonProperty(PropertyName = "DividendYieldTtm")]
    public decimal? DividendYieldTtm { get; set; }
    
    [JsonProperty(PropertyName = "EnterpriseValueMultipleTtm")]
    public decimal? EnterpriseValueMultipleTtm { get; set; }
    
    [JsonProperty(PropertyName = "PriceFairValueTtm")]
    public decimal? PriceFairValueTtm { get; set; }
    
    [JsonProperty(PropertyName = "DividendPerShareTtm")]
    public decimal? DividendPerShareTtm { get; set; }
}