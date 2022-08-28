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

        public virtual DbSet<StockInfoDatumDTO> StockInfoData { get; set; }

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
            modelBuilder.Entity<StockInfoDatumDTO>(entity =>
            {
                entity.Property(e => e.BvS)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BvS");
            
                entity.Property(e => e.BvS1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BvS1");
            
                entity.Property(e => e.BvS2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BvS2");
            
                entity.Property(e => e.BvS3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BvS3");
            
                entity.Property(e => e.BvS4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BvS4");
            
                entity.Property(e => e.CashFlowToSales)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("CashFlowToSales");
            
                entity.Property(e => e.Date).HasColumnName("date");
            
                entity.Property(e => e.DivYield)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("DivYield");
            
                entity.Property(e => e.DivYield1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("DivYield1");
            
                entity.Property(e => e.DivYield2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("DivYield2");
            
                entity.Property(e => e.DivYield3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("DivYield3");
            
                entity.Property(e => e.DivYield4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("DivYield4");
            
                entity.Property(e => e.Eps)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("eps");
            
                entity.Property(e => e.MarketCap)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MarketCap");
            
                entity.Property(e => e.OneDay)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("OneDay");
            
                entity.Property(e => e.PbRatio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PbRatio");
            
                entity.Property(e => e.PeRatio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PeRatio");
            
                entity.Property(e => e.Roe)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Roe");
            
                entity.Property(e => e.Roe_1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Roe_1");
            
                entity.Property(e => e.Roe_2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Roe_2");
            
                entity.Property(e => e.Roe_3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Roe_3");
            
                entity.Property(e => e.Roe_4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Roe_4");
            
                entity.Property(e => e.SixMonths)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SixMonths");
            
                entity.Property(e => e.Symbol).HasColumnName("symbol");
            
                entity.Property(e => e.YoySuccess)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("YoySuccess");
            });

        }
    }
}
