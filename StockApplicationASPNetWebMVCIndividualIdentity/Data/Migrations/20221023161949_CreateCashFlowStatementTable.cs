using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class CreateCashFlowStatementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashFlowStatement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AcceptedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CalendarYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepreciationAndAmortization = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeferredIncomeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockBasedCompensation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChangeInWorkingCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AccountsReceivables = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inventory = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AccountsPayables = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherWorkingCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherNonCashItems = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashProvidedByOperatingActivities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvestmentsInPropertyPlantAndEquipment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AcquisitionsNet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchasesOfInvestments = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalesMaturitiesOfInvestments = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherInvestingActivites = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashUsedForInvestingActivites = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DebtRepayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommonStockIssued = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommonStockRepurchased = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DividendsPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherFinancingActivites = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashUsedProvidedByFinancingActivities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EffectOfForexChangesOnCash = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetChangeInCash = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CashAtEndOfPeriod = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CashAtBeginningOfPeriod = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingCashFlow = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CapitalExpenditure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreeCashFlow = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowStatement", x => x.Id);
                    table.UniqueConstraint("UK_CashFlowStatement_Symbol_Date", x => new {x.Symbol, x.Date});
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFlowStatement");
        }
    }
}
