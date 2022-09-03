

#nullable disable

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class seed_dev_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockInfoData",
                columns: table => new {
                    Id = table.Column<long>().Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    symbol = table.Column<string>(nullable: true),
                    YoySuccess = table.Column<decimal>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    eps = table.Column<decimal>(nullable: true),
                    PbRatio = table.Column<decimal>(nullable: true),
                    PeRatio = table.Column<decimal>(nullable: true),
                    MarketCap = table.Column<decimal>(nullable: true),
                    OneDay = table.Column<decimal>(nullable: true),
                    SixMonths = table.Column<decimal>(nullable: true),
                    CashFlowToSales = table.Column<decimal>(nullable: true),
                    Roe = table.Column<decimal>(nullable: true),
                    Roe_1 = table.Column<decimal>(nullable: true),
                    Roe_2 = table.Column<decimal>(nullable: true),
                    Roe_3 = table.Column<decimal>(nullable: true),
                    Roe_4 = table.Column<decimal>(nullable: true),
                    BvS = table.Column<decimal>(nullable: true),
                    BvS1 = table.Column<decimal>(nullable: true),
                    BvS2 = table.Column<decimal>(nullable: true),
                    BvS3 = table.Column<decimal>(nullable: true),
                    BvS4 = table.Column<decimal>(nullable: true),
                    DivYield = table.Column<decimal>(nullable: true),
                    DivYield1 = table.Column<decimal>(nullable: true),
                    DivYield2 = table.Column<decimal>(nullable: true),
                    DivYield3 = table.Column<decimal>(nullable: true),
                    DivYield4 = table.Column<decimal>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_ids", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
