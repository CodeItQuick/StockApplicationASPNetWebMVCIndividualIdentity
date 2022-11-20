using StockApplication.Core.Tests.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Domain
{
    public class Stock
    {
        private string _stockTicker;

        private readonly Dictionary<string, StockAttributeDecimal> _allStockAttributes =
            new();

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
    }
}