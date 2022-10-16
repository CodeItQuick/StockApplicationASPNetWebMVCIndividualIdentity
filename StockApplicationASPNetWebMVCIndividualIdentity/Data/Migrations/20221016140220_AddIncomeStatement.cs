
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class AddIncomeStatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeStatement",
                columns: table => new {
                    Id = table.Column<long>().Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTimeOffset>(),
                    Symbol = table.Column<string>(),
                    ReportedCurrency = table.Column<string>(),
                    Cik = table.Column<string>(),
                    FillingDate = table.Column<DateTimeOffset>(),
                    AcceptedDate = table.Column<DateTimeOffset>(),
                    CalendarYear = table.Column<string>(),
                    Period = table.Column<string>(),
                    Revenue = table.Column<long>(),
                    CostOfRevenue = table.Column<long>(),
                    GrossProfit = table.Column<long>(),
                    GrossProfitRatio = table.Column<decimal>(),
                    ResearchAndDevelopmentExpenses = table.Column<long>(),
                    GeneralAndAdministrativeExpenses = table.Column<decimal>(),
                    SellingAndMarketingExpenses = table.Column<decimal>(),
                    SellingGeneralAndAdministrativeExpenses = table.Column<long>(),
                    OtherExpenses = table.Column<decimal>(),
                    OperatingExpenses = table.Column<long>(),
                    CostAndExpenses = table.Column<long>(),
                    InterestIncome = table.Column<long>(),
                    InterestExpense = table.Column<long>(),
                    DepreciationAndAmortization = table.Column<long>(),
                    Ebitda = table.Column<long>(),
                    Ebitdaratio = table.Column<decimal>(),
                    OperatingIncome = table.Column<long>(),
                    OperatingIncomeRatio = table.Column<decimal>(),
                    TotalOtherIncomeExpensesNet = table.Column<long>(),
                    IncomeBeforeTax = table.Column<long>(),
                    IncomeBeforeTaxRatio = table.Column<decimal>(),
                    IncomeTaxExpense = table.Column<long>(),
                    NetIncome = table.Column<long>(),
                    NetIncomeRatio = table.Column<decimal>(),
                    Eps = table.Column<decimal>(),
                    Epsdiluted = table.Column<decimal>(),
                    WeightedAverageShsOut = table.Column<long>(),
                    WeightedAverageShsOutDil = table.Column<long>(),
                    Link = table.Column<string>(),
                    FinalLink = table.Column<string>(),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatements_ids", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeStatement");
        }
    }
}
