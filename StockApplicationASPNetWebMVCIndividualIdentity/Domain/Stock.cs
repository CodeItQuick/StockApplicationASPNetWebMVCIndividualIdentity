using StockApplication.Core.Tests.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Domain
{
    public class Stock
    {
        private string _ticker;
        private readonly Dictionary<string, StockAttributeDecimal> _allStockAttributes = 
            new();

        public Stock(string ticker)
        {
            _ticker = ticker;
        }

        public Stock(
            string ticker, List<StockAttributeDecimal> listStocksAttributes)
        {
            _ticker = ticker;
            foreach (StockAttributeDecimal stocksAttributes in listStocksAttributes)
            {
                _allStockAttributes.Add(ticker, stocksAttributes);
            }
        }

        public string Ticker()
        {
            return _ticker;
        }

        public bool IsMatch(string ticker)
        {
            return ticker.Equals(_ticker);
        }

        public decimal? RetrieveAttributeFor(string ticker, string attrib)
        {
            return _allStockAttributes
                .First(r => r.Key.Equals(ticker) && 
                            r.Value.AttributeName.Equals(attrib)).Value.AttributeValue;
        }
    }
}