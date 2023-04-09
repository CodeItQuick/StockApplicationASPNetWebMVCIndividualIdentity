using System.Collections;
using MathNet.Numerics.LinearRegression;
using StockApplication.Core.Tests.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Domain
{
    public class Stock
    {
        private string _stockTicker;

        private readonly Dictionary<string, StockAttributeDecimal> _allStockAttributes =
            new();

        private List<long> _previousPerformance;

        public Stock(string stockTicker)
        {
            _stockTicker = stockTicker;
        }

        public Stock(
            string stockTicker, List<StockAttributeDecimal> listStocksAttributes)
        {
            _stockTicker = stockTicker;
            listStocksAttributes.ForEach(r => { _allStockAttributes.Add(r.AttributeName, r); });
        }

        public string Ticker()
        {
            return _stockTicker;
        }

        public bool IsMatch(string ticker)
        {
            return ticker.Equals(_stockTicker);
        }

        public decimal? RetrieveAttributeFor(string attrib)
        {
            return _allStockAttributes
                .First(r =>
                    r.Value.AttributeName.Equals(attrib)).Value.AttributeValue;
        }

        public void AddDefaultAttributes(decimal PbRatio, decimal peRatio, decimal DivYield, decimal eps,
            decimal? AvgRoe)
        {
            // Investment Value Metrics
            _allStockAttributes.Add("PbRatio", new StockAttributeDecimal("PbRatio", PbRatio));
            _allStockAttributes.Add("PeRatio", new StockAttributeDecimal("PeRatio", peRatio));
            _allStockAttributes.Add("Eps", new StockAttributeDecimal("Eps", eps));
            // Overall good thing to know
            _allStockAttributes.Add("DivYield", new StockAttributeDecimal("DivYield", DivYield));
            _allStockAttributes.Add("AvgRoe", new StockAttributeDecimal("AvgRoe", AvgRoe));
        }

        public Dictionary<string, decimal> Attributes()
        {
            Dictionary<string, decimal> stockDictionary = new Dictionary<string, decimal>();
            _allStockAttributes.ToList().ForEach(r => 
                stockDictionary.Add(r.Key, r.Value.AttributeValue ?? Decimal.Zero));
            return stockDictionary;
        }

        public void IntrinsicValue(List<long> yearsCashFlow)
        {
            _previousPerformance = yearsCashFlow;
        }

        public List<long> Cashflow()
        {
            return _previousPerformance;
        }

        public long StraightLineStockValueForYear(int numProjectedYears)
        {
            // Calculate known Years
            var straightLineStockValueForYear = _previousPerformance
                .Skip(numProjectedYears)
                .Aggregate(0L, (acc, curr) => acc + curr);
            
            //Calculate Projected Years
            var averageFreeCashFlow = Int64.Parse(_previousPerformance.Average(x => x).ToString());
            straightLineStockValueForYear += averageFreeCashFlow * numProjectedYears;
            
            return straightLineStockValueForYear;
        }

        public double RegressionStockValueForYear(int numProjectedYears)
        {   
            var regressionYValues = _previousPerformance
                .Select(stock => Convert.ToDouble(stock))
                .Reverse()
                .ToArray();
            var yearXValues = new[]
            {
                1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0
            };
            if (yearXValues.Length != regressionYValues.Length)
            {
                return 0;
            }
            (double intercept, double slope) = SimpleRegression.Fit(yearXValues, regressionYValues);
            var areaUnderLine = yearXValues.Aggregate((acc, year) => acc + intercept + (year + numProjectedYears) * slope);
            return areaUnderLine;
            
        }

        public decimal CashFlows(int idx)
        {
            return Convert.ToDecimal(_previousPerformance[idx]);
        }
    }
}