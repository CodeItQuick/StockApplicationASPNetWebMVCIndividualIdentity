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

        public void AddDefaultAttributes(decimal roe, decimal PeRatio, decimal MarketCap, decimal eps)
        {
            _allStockAttributes.Add("Roe", new StockAttributeDecimal("Roe", roe));
            _allStockAttributes.Add("PeRatio", new StockAttributeDecimal("PeRatio", PeRatio));
            _allStockAttributes.Add("MarketCap", new StockAttributeDecimal("MarketCap", MarketCap));
            _allStockAttributes.Add("eps", new StockAttributeDecimal("eps", eps));
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