using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository
{
    public class StockContext : IdentityDbContext, IStockContext
    {
        private const string ConnectionString = "data source=localhost,1433; User Id=sa; password=Sqlserver0!; Database=stock;Integrated Security=false;";

        public StockContext()
        {
        }

        public StockContext(DbContextOptions<StockContext> options): base(options)
        {
            
        }

        public virtual DbSet<KeyMetricsDto>? KeyMetrics { get; set; }
        public virtual DbSet<ShortlistDto>? Shortlists { get; set; }
        public virtual DbSet<IndividualStockDto>? IndividualStocks { get; set; }
        public virtual DbSet<SubscriptionsDto>? Subscriptions { get; set; }
        public virtual DbSet<CashFlowStatementDto>? CashFlowStatement { get; set; }
        public virtual DbSet<IncomeStatementDto>? IncomeStatements { get; set; }
        public virtual DbSet<RatiosDto>? Ratios { get; set; }
        public virtual DbSet<ShortlistStockInfoDataView> ShortlistStockInfoDataView { get; set; }
        public virtual DbSet<StockInfoDatumDTO> StockRepository { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<ApplicationUser>();
        }

    }

    public interface IStockContext
    {
        public abstract DbSet<KeyMetricsDto>? KeyMetrics { get; set; }
        public abstract DbSet<ShortlistDto>? Shortlists { get; set; }
        public abstract DbSet<IndividualStockDto>? IndividualStocks { get; set; }
        public abstract DbSet<SubscriptionsDto>? Subscriptions { get; set; }
        public abstract DbSet<CashFlowStatementDto>? CashFlowStatement { get; set; }
        public abstract DbSet<ShortlistStockInfoDataView> ShortlistStockInfoDataView { get; set; }
        public abstract DbSet<StockInfoDatumDTO> StockRepository { get; set; }
    }
}
