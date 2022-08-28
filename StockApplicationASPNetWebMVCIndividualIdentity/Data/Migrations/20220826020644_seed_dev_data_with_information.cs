

#nullable disable

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore.Migrations;
using StockApplicationASPNetWebMVCIndividualIdentity.Models;

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
                    var allRecords = csv.GetRecords<StockInfoDatum>().ToList();
                    IEnumerable<StockInfoDatum> recordsFirstBatch = allRecords
                         .Where((x, idx) => idx < 1000)
                         .ToList();
                    IEnumerable<StockInfoDatum> recordsSecondBatch = allRecords
                        .Where((x, idx) => idx >= 1000 && idx < 2000)
                        .ToList();
                    IEnumerable<StockInfoDatum> recordsThirdBatch = allRecords
                        .Where((x, idx) => idx >= 2000 && idx < 3000)
                        .ToList();
                    IEnumerable<StockInfoDatum> recordsFourthBatch = allRecords
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
                    "Symbol",
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
                    "Roe_1",
                    "Roe_2",
                    "Roe_3",
                    "Roe_4",
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
                    "decimal(18,2)",
                },
                values: convertedRecords);
        }

        private static object[,] ConvertedRecords(int idx, IEnumerable<StockInfoDatum> recordsForBatch)
        {
            var sizeOfArray = recordsForBatch.ToList().Count;
            Console.WriteLine(sizeOfArray);
            object[,] convertedRecords = new object[sizeOfArray, 26];
            foreach (var stockInfoData in recordsForBatch)
            {
                convertedRecords[idx, 0] = stockInfoData.Id;
                convertedRecords[idx, 1] = stockInfoData.Symbol;
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
                convertedRecords[idx, 11] = stockInfoData.Roe1;
                convertedRecords[idx, 11] = stockInfoData.Roe2;
                convertedRecords[idx, 11] = stockInfoData.Roe3;
                convertedRecords[idx, 11] = stockInfoData.Roe4;
                convertedRecords[idx, 16] = stockInfoData.BvS;
                convertedRecords[idx, 16] = stockInfoData.BvS1;
                convertedRecords[idx, 16] = stockInfoData.BvS2;
                convertedRecords[idx, 16] = stockInfoData.BvS3;
                convertedRecords[idx, 16] = stockInfoData.BvS4;
                convertedRecords[idx, 21] = stockInfoData.DivYield;
                convertedRecords[idx, 21] = stockInfoData.DivYield1;
                convertedRecords[idx, 21] = stockInfoData.DivYield2;
                convertedRecords[idx, 21] = stockInfoData.DivYield3;
                convertedRecords[idx, 21] = stockInfoData.DivYield4;
                idx++;
            }

            return convertedRecords;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
