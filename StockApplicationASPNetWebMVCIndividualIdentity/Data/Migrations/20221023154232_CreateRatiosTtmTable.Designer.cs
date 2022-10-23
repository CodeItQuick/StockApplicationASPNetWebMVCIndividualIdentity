﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

#nullable disable

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    [DbContext(typeof(StockContext))]
    [Migration("20221023154232_CreateRatiosTtmTable")]
    partial class CreateRatiosTtmTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StockApplication.Core.Tests.Application.ShortlistStockInfoDataView", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("long")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal?>("Eps")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Eps");

                    b.Property<decimal?>("MarketCap")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MarketCap");

                    b.Property<decimal?>("PeRatio")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PeRatio");

                    b.Property<decimal?>("Roe")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Roe");

                    b.Property<string>("Ticker")
                        .HasColumnType("string")
                        .HasColumnName("Ticker");

                    b.Property<long>("TickerId")
                        .HasColumnType("long")
                        .HasColumnName("TickerId");

                    b.Property<string>("UserId")
                        .HasColumnType("long")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("ShortlistStockInfoDataView");
                });

            modelBuilder.Entity("StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService.ShortlistDto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("StockInfoDataId")
                        .HasColumnType("bigint");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("string")
                        .HasColumnName("Ticker");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shortlist");
                });

            modelBuilder.Entity("StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics.KeyMetricsDto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal?>("AverageInventory")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AveragePayables")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AverageReceivables")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BookValuePerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CapexPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CapexToDepreciation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CapexToOperatingCashFlow")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CapexToRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CashPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("DaysOfInventoryOnHand")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DaysPayablesOutstanding")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DaysSalesOutstanding")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DebtToAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DebtToEquity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DividendYield")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EarningsYield")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EnterpriseValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EnterpriseValueOverEbitda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EvToFreeCashFlow")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EvToOperatingCashFlow")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EvToSales")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FreeCashFlowPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FreeCashFlowYield")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GrahamNetNet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GrahamNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("IncomeQuality")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("IntangiblesToTotalAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("InterestCoverage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("InterestDebtPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("InventoryTurnover")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("InvestedCapital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MarketCap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCurrentAssetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetDebtToEbitda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetIncomePerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingCashFlowPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PayablesTurnover")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PayoutRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PbRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PeRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PfcfRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Pocfratio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceToSalesRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PtbRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReceivablesTurnover")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ResearchAndDdevelopementToRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReturnOnTangibleAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("RevenuePerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Roe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Roic")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SalesGeneralAndAdministrativeToRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ShareholdersEquityPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("StockBasedCompensationToRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TangibleAssetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TangibleBookValuePerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("WorkingCapital")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("KeyMetrics", (string)null);
                });

            modelBuilder.Entity("StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM.RatiosTtmDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("AssetTurnoverTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CapitalExpenditureCoverageRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CashConversionCycleTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CashFlowCoverageRatiosTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CashFlowToDebtRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CashPerShareTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CashRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CompanyEquityMultiplierTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DaysOfInventoryOutstandingTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DaysOfPayablesOutstandingTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DaysOfSalesOutstandingTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DebtEquityRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DebtRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DividendPaidAndCapexCoverageRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DividendPerShareTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DividendYielPercentageTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DividendYielTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DividendYieldTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EbitPerRevenueTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EbtPerEbitTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EffectiveTaxRateTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EnterpriseValueMultipleTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FixedAssetTurnoverTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FreeCashFlowOperatingCashFlowRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FreeCashFlowPerShareTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GrossProfitMarginTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("InterestCoverageTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("InventoryTurnoverTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("LongTermDebtToCapitalizationTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetIncomePerEbtttm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetProfitMarginTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingCashFlowPerShareTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingCashFlowSalesRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingCycleTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingProfitMarginTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PayablesTurnoverTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PayoutRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PeRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PegRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PretaxProfitMarginTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceBookValueRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceCashFlowRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceEarningsRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceEarningsToGrowthRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceFairValueTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceSalesRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceToBookRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceToFreeCashFlowsRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceToOperatingCashFlowsRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceToSalesRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("QuickRatioTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReceivablesTurnoverTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReturnOnAssetsTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReturnOnCapitalEmployedTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReturnOnEquityTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ShortTermCoverageRatiosTtm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalDebtToCapitalizationTtm")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("RatiosTTM", (string)null);
                });

            modelBuilder.Entity("StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements.IncomeStatementDto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("AcceptedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CalendarYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CostAndExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("CostOfRevenue")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("DepreciationAndAmortization")
                        .HasColumnType("bigint");

                    b.Property<long>("Ebitda")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Ebitdaratio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Eps")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Epsdiluted")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("FillingDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FinalLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GeneralAndAdministrativeExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("GrossProfit")
                        .HasColumnType("bigint");

                    b.Property<decimal>("GrossProfitRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("IncomeBeforeTax")
                        .HasColumnType("bigint");

                    b.Property<decimal>("IncomeBeforeTaxRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("IncomeTaxExpense")
                        .HasColumnType("bigint");

                    b.Property<long>("InterestExpense")
                        .HasColumnType("bigint");

                    b.Property<long>("InterestIncome")
                        .HasColumnType("bigint");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NetIncome")
                        .HasColumnType("bigint");

                    b.Property<decimal>("NetIncomeRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("OperatingExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("OperatingIncome")
                        .HasColumnType("bigint");

                    b.Property<decimal>("OperatingIncomeRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OtherExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportedCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ResearchAndDevelopmentExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("Revenue")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SellingAndMarketingExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("SellingGeneralAndAdministrativeExpenses")
                        .HasColumnType("bigint");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TotalOtherIncomeExpensesNet")
                        .HasColumnType("bigint");

                    b.Property<long>("WeightedAverageShsOut")
                        .HasColumnType("bigint");

                    b.Property<long>("WeightedAverageShsOutDil")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("IncomeStatement", (string)null);
                });

            modelBuilder.Entity("StockApplicationASPNetWebMVCIndividualIdentity.Application.Models.StockInfoDatumDTO", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal?>("BvS")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("BvS");

                    b.Property<decimal?>("BvS1")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("BvS1");

                    b.Property<decimal?>("BvS2")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("BvS2");

                    b.Property<decimal?>("BvS3")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("BvS3");

                    b.Property<decimal?>("BvS4")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("BvS4");

                    b.Property<decimal?>("CashFlowToSales")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CashFlowToSales");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("date");

                    b.Property<decimal?>("DivYield")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("DivYield");

                    b.Property<decimal?>("DivYield1")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("DivYield1");

                    b.Property<decimal?>("DivYield2")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("DivYield2");

                    b.Property<decimal?>("DivYield3")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("DivYield3");

                    b.Property<decimal?>("DivYield4")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("DivYield4");

                    b.Property<decimal?>("Eps")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Eps");

                    b.Property<decimal?>("MarketCap")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MarketCap");

                    b.Property<decimal?>("OneDay")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("OneDay");

                    b.Property<decimal?>("PbRatio")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PbRatio");

                    b.Property<decimal?>("PeRatio")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PeRatio");

                    b.Property<decimal?>("Roe")
                        .HasColumnType("decimal(18,16)")
                        .HasColumnName("Roe");

                    b.Property<decimal?>("Roe1")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Roe1");

                    b.Property<decimal?>("Roe2")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Roe2");

                    b.Property<decimal?>("Roe3")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Roe3");

                    b.Property<decimal?>("Roe4")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Roe4");

                    b.Property<decimal?>("SixMonths")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("SixMonths");

                    b.Property<string>("Ticker")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ticker");

                    b.Property<decimal?>("YoySuccess")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("YoySuccess");

                    b.HasKey("Id");

                    b.ToTable("StockInfoData");
                });

            modelBuilder.Entity("StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("StripeCustomerId")
                        .HasColumnType("string")
                        .HasColumnName("StripeCustomerId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
