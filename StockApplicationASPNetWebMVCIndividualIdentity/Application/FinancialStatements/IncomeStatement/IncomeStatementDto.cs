using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Newtonsoft.Json;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;

[Table("IncomeStatement")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class IncomeStatementDto : IEntityId
{
    [Key]
    [JsonProperty(PropertyName = "Id")]
    public long Id { get; set; }
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
    [JsonProperty(PropertyName = "Revenue")]
    public long Revenue { get; set; }
    [JsonProperty(PropertyName = "CostOfRevenue")]
    public long CostOfRevenue { get; set; }
    [JsonProperty(PropertyName = "GrossProfit")]
    public long GrossProfit { get; set; }
    [JsonProperty(PropertyName = "GrossProfitRatio")]
    public decimal GrossProfitRatio { get; set; }
    [JsonProperty(PropertyName = "ResearchAndDevelopmentExpenses")]
    public long ResearchAndDevelopmentExpenses { get; set; }
    [JsonProperty(PropertyName = "GeneralAndAdministrativeExpenses")]
    public decimal GeneralAndAdministrativeExpenses { get; set; }
    [JsonProperty(PropertyName = "SellingAndMarketingExpenses")]
    public decimal SellingAndMarketingExpenses { get; set; }
    [JsonProperty(PropertyName = "SellingGeneralAndAdministrativeExpenses")]
    public long SellingGeneralAndAdministrativeExpenses { get; set; }
    [JsonProperty(PropertyName = "OtherExpenses")]
    public decimal OtherExpenses { get; set; }
    [JsonProperty(PropertyName = "OperatingExpenses")]
    public long OperatingExpenses { get; set; }
    [JsonProperty(PropertyName = "CostAndExpenses")]
    public long CostAndExpenses { get; set; }
    [JsonProperty(PropertyName = "InterestIncome")]
    public long InterestIncome { get; set; }
    [JsonProperty(PropertyName = "InterestExpense")]
    public long InterestExpense { get; set; }
    [JsonProperty(PropertyName = "DepreciationAndAmortization")]
    public long DepreciationAndAmortization { get; set; }
    [JsonProperty(PropertyName = "Ebitda")]
    public long Ebitda { get; set; }
    [JsonProperty(PropertyName = "Ebitdaratio")]
    public decimal Ebitdaratio { get; set; }
    [JsonProperty(PropertyName = "OperatingIncome")]
    public long OperatingIncome { get; set; }
    [JsonProperty(PropertyName = "OperatingIncomeRatio")]
    public decimal OperatingIncomeRatio { get; set; }
    [JsonProperty(PropertyName = "TotalOtherIncomeExpensesNet")]
    public long TotalOtherIncomeExpensesNet { get; set; }
    [JsonProperty(PropertyName = "IncomeBeforeTax")]
    public long IncomeBeforeTax { get; set; }
    [JsonProperty(PropertyName = "IncomeBeforeTaxRatio")]
    public decimal IncomeBeforeTaxRatio { get; set; }
    [JsonProperty(PropertyName = "IncomeTaxExpense")]
    public long IncomeTaxExpense { get; set; }
    [JsonProperty(PropertyName = "NetIncome")]
    public long NetIncome { get; set; }
    [JsonProperty(PropertyName = "NetIncomeRatio")]
    public decimal NetIncomeRatio { get; set; }
    [JsonProperty(PropertyName = "Eps")]
    public decimal Eps { get; set; }
    [JsonProperty(PropertyName = "Epsdiluted")]
    public decimal Epsdiluted { get; set; }
    [JsonProperty(PropertyName = "WeightedAverageShsOut")]
    public long WeightedAverageShsOut { get; set; }
    [JsonProperty(PropertyName = "WeightedAverageShsOutDil")]
    public long WeightedAverageShsOutDil { get; set; }
    [JsonProperty(PropertyName = "Link")]
    public string Link { get; set; }
    [JsonProperty(PropertyName = "FinalLink")]
    public string FinalLink { get; set; }
}