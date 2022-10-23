using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

[Table("CashFlowStatement")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class CashFlowStatementDto
{
    public DateTimeOffset Date { get; set; }
    public string Symbol { get; set; }
    public string ReportedCurrency { get; set; }
    public string Cik { get; set; }
    public DateTimeOffset FillingDate { get; set; }
    public DateTimeOffset AcceptedDate { get; set; }
    public string CalendarYear { get; set; }
    public string Period { get; set; }
    public decimal? NetIncome { get; set; }
    public decimal? DepreciationAndAmortization { get; set; }
    public decimal? DeferredIncomeTax { get; set; }
    public decimal? StockBasedCompensation { get; set; }
    public decimal? ChangeInWorkingCapital { get; set; }
    public decimal? AccountsReceivables { get; set; }
    public decimal? Inventory { get; set; }
    public decimal? AccountsPayables { get; set; }
    public decimal? OtherWorkingCapital { get; set; }
    public decimal? OtherNonCashItems { get; set; }
    public decimal? NetCashProvidedByOperatingActivities { get; set; }
    public decimal? InvestmentsInPropertyPlantAndEquipment { get; set; }
    public decimal? AcquisitionsNet { get; set; }
    public decimal? PurchasesOfInvestments { get; set; }
    public decimal? SalesMaturitiesOfInvestments { get; set; }
    public decimal? OtherInvestingActivites { get; set; }
    public decimal? NetCashUsedForInvestingActivites { get; set; }
    public decimal? DebtRepayment { get; set; }
    public decimal? CommonStockIssued { get; set; }
    public decimal? CommonStockRepurchased { get; set; }
    public decimal? DividendsPaid { get; set; }
    public decimal? OtherFinancingActivites { get; set; }
    public decimal? NetCashUsedProvidedByFinancingActivities { get; set; }
    public decimal? EffectOfForexChangesOnCash { get; set; }
    public decimal? NetChangeInCash { get; set; }
    public decimal? CashAtEndOfPeriod { get; set; }
    public decimal? CashAtBeginningOfPeriod { get; set; }
    public decimal? OperatingCashFlow { get; set; }
    public decimal? CapitalExpenditure { get; set; }
    public decimal? FreeCashFlow { get; set; }
    public string Link { get; set; }
    public string FinalLink { get; set; }

}