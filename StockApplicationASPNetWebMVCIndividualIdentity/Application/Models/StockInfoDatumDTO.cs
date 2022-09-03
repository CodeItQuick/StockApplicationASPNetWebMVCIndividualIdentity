using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Models
{
    [Table("StockInfoData")]
    public class StockInfoDatumDTO
    {
        [Key]
        public long Id { get; set; }
        public string? Symbol { get; set; }
        public decimal? YoySuccess { get; set; }
        public string? Date { get; set; }
        public decimal? Eps { get; set; }
        public decimal? PbRatio { get; set; }
        public decimal? PeRatio { get; set; }
        public double? MarketCap { get; set; }
        public decimal? OneDay { get; set; }
        public decimal? SixMonths { get; set; }
        public decimal? CashFlowToSales { get; set; }
        public decimal? Roe { get; set; }
        public decimal? Roe_1 { get; set; }
        public decimal? Roe_2 { get; set; }
        public decimal? Roe_3 { get; set; }
        public decimal? Roe_4 { get; set; }
        public decimal? BvS { get; set; }
        public decimal? BvS1 { get; set; }
        public decimal? BvS2 { get; set; }
        public decimal? BvS3 { get; set; }
        public decimal? BvS4 { get; set; }
        public decimal? DivYield { get; set; }
        public decimal? DivYield1 { get; set; }
        public decimal? DivYield2 { get; set; }
        public decimal? DivYield3 { get; set; }
        public decimal? DivYield4 { get; set; }
    }
}
