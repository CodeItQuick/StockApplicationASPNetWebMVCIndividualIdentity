﻿

#nullable disable

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore.Migrations;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class seed_dev_data_with_information : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null
            };
            using (var reader = new StreamReader("Data\\Migrations\\stocksinfo.csv"))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    var allRecords = csv.GetRecords<StockInfoDatumDTO>().ToList();
                    IEnumerable<StockInfoDatumDTO> recordsFirstBatch = allRecords
                         .Where((x, idx) => idx < 1000)
                         .ToList();
                    IEnumerable<StockInfoDatumDTO> recordsSecondBatch = allRecords
                        .Where((x, idx) => idx >= 1000 && idx < 2000)
                        .ToList();
                    IEnumerable<StockInfoDatumDTO> recordsThirdBatch = allRecords
                        .Where((x, idx) => idx >= 2000 && idx < 3000)
                        .ToList();
                    IEnumerable<StockInfoDatumDTO> recordsFourthBatch = allRecords
                        .Where((x, idx) => idx >= 3000)
                        .ToList();

                    var convertedRecordsFirstBatch = ConvertedRecords(0, recordsFirstBatch);
                    writeMigrationForBatch(migrationBuilder, convertedRecordsFirstBatch);
                    var convertedRecordsSecondBatch = ConvertedRecords(0, recordsSecondBatch);
                    writeMigrationForBatch(migrationBuilder, convertedRecordsSecondBatch);
                    var convertedRecordsThirdBatch = ConvertedRecords(0, recordsThirdBatch);
                    writeMigrationForBatch(migrationBuilder, convertedRecordsThirdBatch);
                    var convertedRecordsFourthBatch = ConvertedRecords(0, recordsFourthBatch);
                    writeMigrationForBatch(migrationBuilder, convertedRecordsFourthBatch);
                }
            }
        }

        private static void writeMigrationForBatch(
            MigrationBuilder migrationBuilder, 
            object[,] convertedRecords)
        {
            migrationBuilder.InsertData(
                table: "StockInfoData",
                columns: new[]
                {
                    "Id",
                    "Ticker",
                    "YoySuccess",
                    "date",
                    "eps",
                    "PbRatio",
                    "PeRatio",
                    "MarketCap",
                    "OneDay",
                    "SixMonths",
                    "CashFlowToSales",
                    "Roe",
                    "Roe1",
                    "Roe2",
                    "Roe3",
                    "Roe4",
                    "BvS",
                    "BvS1",
                    "BvS2",
                    "BvS3",
                    "BvS4",
                    "DivYield",
                    "DivYield1",
                    "DivYield2",
                    "DivYield3",
                    "DivYield4"
                },
                columnTypes: new[]
                {
                    "bigint",
                    "nvarchar(max)",
                    "decimal(18,2)",
                    "nvarchar(max)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,16)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                    "decimal(18,2)",
                },
                values: convertedRecords);
        }

        private static object[,] ConvertedRecords(int idx, IEnumerable<StockInfoDatumDTO> recordsForBatch)
        {
            var sizeOfArray = recordsForBatch.ToList().Count;
            Console.WriteLine(sizeOfArray);
            object[,] convertedRecords = new object[sizeOfArray, 26];
            foreach (var stockInfoData in recordsForBatch)
            {
                convertedRecords[idx, 0] = stockInfoData.Id;
                convertedRecords[idx, 1] = stockInfoData.Ticker;
                convertedRecords[idx, 2] = stockInfoData.YoySuccess;
                convertedRecords[idx, 3] = stockInfoData.Date;
                convertedRecords[idx, 4] = stockInfoData.Eps;
                convertedRecords[idx, 5] = stockInfoData.PbRatio;
                convertedRecords[idx, 6] = stockInfoData.PeRatio;
                convertedRecords[idx, 7] = stockInfoData.MarketCap;
                convertedRecords[idx, 8] = stockInfoData.OneDay;
                convertedRecords[idx, 9] = stockInfoData.SixMonths;
                convertedRecords[idx, 10] = stockInfoData.CashFlowToSales;
                convertedRecords[idx, 11] = stockInfoData.Roe;
                convertedRecords[idx, 12] = stockInfoData.Roe1;
                convertedRecords[idx, 13] = stockInfoData.Roe2;
                convertedRecords[idx, 14] = stockInfoData.Roe3;
                convertedRecords[idx, 15] = stockInfoData.Roe4;
                convertedRecords[idx, 16] = stockInfoData.BvS;
                convertedRecords[idx, 17] = stockInfoData.BvS1;
                convertedRecords[idx, 18] = stockInfoData.BvS2;
                convertedRecords[idx, 19] = stockInfoData.BvS3;
                convertedRecords[idx, 20] = stockInfoData.BvS4;
                convertedRecords[idx, 21] = stockInfoData.DivYield;
                convertedRecords[idx, 22] = stockInfoData.DivYield1;
                convertedRecords[idx, 23] = stockInfoData.DivYield2;
                convertedRecords[idx, 24] = stockInfoData.DivYield3;
                convertedRecords[idx, 25] = stockInfoData.DivYield4;
                idx++;
            }

            return convertedRecords;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
