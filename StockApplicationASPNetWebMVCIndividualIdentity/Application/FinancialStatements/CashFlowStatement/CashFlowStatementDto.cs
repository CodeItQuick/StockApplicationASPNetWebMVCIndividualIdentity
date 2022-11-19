using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;

[Table("CashFlowStatement")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class CashFlowStatementDto
{
    [Key]
    [JsonProperty(PropertyName = "Id")]
    public int Id { get; set; }
    [JsonProperty(PropertyName = "Date")]
    public DateTimeOffset Date { get; set; }
    [JsonProperty(PropertyName = "Symbol")]
    public string Symbol { get; set; }
    [JsonProperty(PropertyName = "ReportedCurrency")]
    public string ReportedCurrency { get; set; }
    [JsonProperty(PropertyName = "Cik")]
    public string Cik { get; set; }
    [JsonProperty(PropertyName = "FillingDate")]
    public DateTimeOffset FillingDate { get; set; }
    [JsonProperty(PropertyName = "AcceptedDate")]
    public DateTimeOffset AcceptedDate { get; set; }
    [JsonProperty(PropertyName = "CalendarYear")]
    public string CalendarYear { get; set; }
    [JsonProperty(PropertyName = "Period")]
    public string Period { get; set; }
    [JsonProperty(PropertyName = "NetIncome")]
    public decimal? NetIncome { get; set; }
    [JsonProperty(PropertyName = "DepreciationAndAmortization")]
    public decimal? DepreciationAndAmortization { get; set; }
    [JsonProperty(PropertyName = "DeferredIncomeTax")]
    public decimal? DeferredIncomeTax { get; set; }
    [JsonProperty(PropertyName = "StockBasedCompensation")]
    public decimal? StockBasedCompensation { get; set; }
    [JsonProperty(PropertyName = "ChangeInWorkingCapital")]
    public decimal? ChangeInWorkingCapital { get; set; }
    [JsonProperty(PropertyName = "AccountsReceivables")]
    public decimal? AccountsReceivables { get; set; }
    [JsonProperty(PropertyName = "Inventory")]
    public decimal? Inventory { get; set; }
    [JsonProperty(PropertyName = "AccountsPayables")]
    public decimal? AccountsPayables { get; set; }
    [JsonProperty(PropertyName = "OtherWorkingCapital")]
    public decimal? OtherWorkingCapital { get; set; }
    [JsonProperty(PropertyName = "OtherNonCashItems")]
    public decimal? OtherNonCashItems { get; set; }
    [JsonProperty(PropertyName = "NetCashProvidedByOperatingActivities")]
    public decimal? NetCashProvidedByOperatingActivities { get; set; }
    [JsonProperty(PropertyName = "InvestmentsInPropertyPlantAndEquipment")]
    public decimal? InvestmentsInPropertyPlantAndEquipment { get; set; }
    [JsonProperty(PropertyName = "AcquisitionsNet")]
    public decimal? AcquisitionsNet { get; set; }
    [JsonProperty(PropertyName = "PurchasesOfInvestments")]
    public decimal? PurchasesOfInvestments { get; set; }
    [JsonProperty(PropertyName = "SalesMaturitiesOfInvestments")]
    public decimal? SalesMaturitiesOfInvestments { get; set; }
    [JsonProperty(PropertyName = "OtherInvestingActivites")]
    public decimal? OtherInvestingActivites { get; set; }
    [JsonProperty(PropertyName = "NetCashUsedForInvestingActivites")]
    public decimal? NetCashUsedForInvestingActivites { get; set; }
    [JsonProperty(PropertyName = "DebtRepayment")]
    public decimal? DebtRepayment { get; set; }
    [JsonProperty(PropertyName = "CommonStockIssued")]
    public decimal? CommonStockIssued { get; set; }
    [JsonProperty(PropertyName = "CommonStockRepurchased")]
    public decimal? CommonStockRepurchased { get; set; }
    [JsonProperty(PropertyName = "DividendsPaid")]
    public decimal? DividendsPaid { get; set; }
    [JsonProperty(PropertyName = "OtherFinancingActivites")]
    public decimal? OtherFinancingActivites { get; set; }
    [JsonProperty(PropertyName = "NetCashUsedProvidedByFinancingActivities")]
    public decimal? NetCashUsedProvidedByFinancingActivities { get; set; }
    [JsonProperty(PropertyName = "EffectOfForexChangesOnCash")]
    public decimal? EffectOfForexChangesOnCash { get; set; }
    [JsonProperty(PropertyName = "NetChangeInCash")]
    public decimal? NetChangeInCash { get; set; }
    [JsonProperty(PropertyName = "CashAtEndOfPeriod")]
    public decimal? CashAtEndOfPeriod { get; set; }
    [JsonProperty(PropertyName = "CashAtBeginningOfPeriod")]
    public decimal? CashAtBeginningOfPeriod { get; set; }
    [JsonProperty(PropertyName = "OperatingCashFlow")]
    public decimal? OperatingCashFlow { get; set; }
    [JsonProperty(PropertyName = "CapitalExpenditure")]
    public decimal? CapitalExpenditure { get; set; }
    [JsonProperty(PropertyName = "FreeCashFlow")]
    public decimal? FreeCashFlow { get; set; }
    [JsonProperty(PropertyName = "Link")]
    public string Link { get; set; }
    [JsonProperty(PropertyName = "FinalLink")]
    public string FinalLink { get; set; }

}