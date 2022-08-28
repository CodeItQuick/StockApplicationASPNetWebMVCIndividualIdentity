using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using StockApplicationASPNetWebMVCIndividualIdentity.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data
{
    public class stockContext : IdentityDbContext
    {
        private string? _connectionString;

        public stockContext(DbContextOptions<stockContext> options)
            : base(options)
        {
            var sqlServerOptionsExtension = 
                options.FindExtension<SqlServerOptionsExtension>();
            if(sqlServerOptionsExtension != null)
            {
                _connectionString = sqlServerOptionsExtension.ConnectionString;
            }
        }

        public virtual DbSet<StockInfoDatum> StockInfoData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && _connectionString != null)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StockInfoDatum>(entity =>
            {
                entity.Property(e => e.BvS)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("bv_s");

                entity.Property(e => e.BvS1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("bv_s_1");

                entity.Property(e => e.BvS2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("bv_s_2");

                entity.Property(e => e.BvS3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("bv_s_3");

                entity.Property(e => e.BvS4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("bv_s_4");

                entity.Property(e => e.CashFlowToSales)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cash_flow_to_sales");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.DivYield)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("div_yield");

                entity.Property(e => e.DivYield1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("div_yield_1");

                entity.Property(e => e.DivYield2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("div_yield_2");

                entity.Property(e => e.DivYield3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("div_yield_3");

                entity.Property(e => e.DivYield4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("div_yield_4");

                entity.Property(e => e.Eps)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("eps");

                entity.Property(e => e.MarketCap)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("market_cap");

                entity.Property(e => e.OneDay)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("one_day");

                entity.Property(e => e.PbRatio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pb_ratio");

                entity.Property(e => e.PeRatio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pe_ratio");

                entity.Property(e => e.Roe)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("roe");

                entity.Property(e => e.Roe1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("roe_1");

                entity.Property(e => e.Roe2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("roe_2");

                entity.Property(e => e.Roe3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("roe_3");

                entity.Property(e => e.Roe4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("roe_4");

                entity.Property(e => e.SixMonths)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("six_months");

                entity.Property(e => e.Symbol).HasColumnName("symbol");

                entity.Property(e => e.YoySuccess)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("yoy_success");
            });

        }
    }
}
