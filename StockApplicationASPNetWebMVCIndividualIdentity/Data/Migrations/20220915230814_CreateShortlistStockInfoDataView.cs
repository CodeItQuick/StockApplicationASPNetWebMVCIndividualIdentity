using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class CreateShortlistStockInfoDataView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("CREATE VIEW dbo.ShortlistStockInfoDataView AS " +
                                 "SELECT " +
                                 "Shortlist.Id AS Id, StockInfoData.Id AS TickerId, Shortlist.Ticker AS Ticker, " +
                                 "Shortlist.UserId, StockInfoData.Eps, StockInfoData.PeRatio, StockInfoData.MarketCap, " +
                                 "StockInfoData.Roe " +
                                 "FROM " +
                                 "StockInfoData " +
                                 "JOIN Shortlist ON Shortlist.StockInfoDataId = StockInfoData.Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP ");
        }
    }
}
