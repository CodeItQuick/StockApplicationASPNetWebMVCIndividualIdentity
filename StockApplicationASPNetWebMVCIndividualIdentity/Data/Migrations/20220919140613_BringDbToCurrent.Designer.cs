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
    [Migration("20220919140613_BringDbToCurrent")]
    partial class BringDbToCurrent
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

                    b.Property<long>("UserId")
                        .HasColumnType("long")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("ShortlistStockInfoDataView");
                });

            modelBuilder.Entity("StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService.ShortlistDto", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"), 1L, 1);

                    b.Property<long>("StockInfoDataId")
                        .HasColumnType("bigint");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("string")
                        .HasColumnName("Ticker");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Shortlist");
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
