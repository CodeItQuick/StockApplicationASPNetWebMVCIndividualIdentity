using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository
{
    public class StockContext : IdentityDbContext
    {
        private string? _connectionString;

        public StockContext()
        {
            _connectionString = "data source=localhost,1433; User Id=sa; password=Sqlserver0!; Database=stock;Integrated Security=false;";
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        // _Some_ kind of creational pattern seems like it would be useful here,
        // I see its a "modelBuilder", but how to add multiple properties to
        // the builder properly? is factory method a solution?
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IncomeStatementDto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("IncomeStatement");
            });
            modelBuilder.Entity<KeyMetricsDto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("KeyMetrics");
            });
            modelBuilder.Entity<RatiosDto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("RatiosTTM");
            });
            modelBuilder.Entity<CashFlowStatementDto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("CashFlowStatement");
            });
            modelBuilder.Entity<ShortlistDto>(entity =>
            {
                entity.Property(e => e.Ticker)
                    .HasColumnType("string")
                    .HasColumnName(nameof(StockInfoDatumDTO.Ticker));
            });
            modelBuilder.Entity<ShortlistStockInfoDataView>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("long")
                    .HasColumnName(nameof(ShortlistStockInfoDataView.Id));
                entity.Property(e => e.UserId)
                    .HasColumnType("long")
                    .HasColumnName(nameof(ShortlistStockInfoDataView.UserId));
                entity.Property(e => e.TickerId)
                    .HasColumnType("long")
                    .HasColumnName(nameof(ShortlistStockInfoDataView.TickerId));
                entity.Property(e => e.Ticker)
                    .HasColumnType("string")
                    .HasColumnName(nameof(ShortlistStockInfoDataView.Ticker));
                entity.Property(e => e.Eps)
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName(nameof(ShortlistStockInfoDataView.Eps));
                entity.Property(e => e.Roe)
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName(nameof(ShortlistStockInfoDataView.Roe));
                entity.Property(e => e.PeRatio)
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName(nameof(ShortlistStockInfoDataView.PeRatio));
                entity.Property(e => e.MarketCap)
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName(nameof(ShortlistStockInfoDataView.MarketCap));
            });
            modelBuilder.Entity<StockInfoDatumDTO>(entity =>
            {
                entity.Property(e => e.BvS)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.BvS));
            
                entity.Property(e => e.BvS1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.BvS1));
            
                entity.Property(e => e.BvS2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.BvS2));
            
                entity.Property(e => e.BvS3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.BvS3));
            
                entity.Property(e => e.BvS4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.BvS4));
            
                entity.Property(e => e.CashFlowToSales)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.CashFlowToSales));
            
                entity.Property(e => e.Date).HasColumnName("date");
            
                entity.Property(e => e.DivYield)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.DivYield));
            
                entity.Property(e => e.DivYield1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.DivYield1));
            
                entity.Property(e => e.DivYield2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.DivYield2));
            
                entity.Property(e => e.DivYield3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.DivYield3));
            
                entity.Property(e => e.DivYield4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.DivYield4));
            
                entity.Property(e => e.Eps)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.Eps));
            
                entity.Property(e => e.MarketCap)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.MarketCap));
            
                entity.Property(e => e.OneDay)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.OneDay));
            
                entity.Property(e => e.PbRatio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.PbRatio));
            
                entity.Property(e => e.PeRatio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.PeRatio));
            
                entity.Property(e => e.Roe)
                    .HasColumnType("decimal(18, 16)")
                    .HasColumnName(nameof(StockInfoDatumDTO.Roe));
            
                entity.Property(e => e.Roe1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.Roe1));
            
                entity.Property(e => e.Roe2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.Roe2));
            
                entity.Property(e => e.Roe3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.Roe3));
            
                entity.Property(e => e.Roe4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName(nameof(StockInfoDatumDTO.Roe4));
            
                entity.Property(e => e.SixMonths)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SixMonths");
            
                entity.Property(e => e.Ticker).HasColumnName("ticker");
            
                entity.Property(e => e.YoySuccess)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("YoySuccess");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.StripeCustomerId)
                    .HasColumnType("string")
                    .HasColumnName("StripeCustomerId");
            });

        }
    }
}
