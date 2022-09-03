namespace StockApplication.Core.Tests.Domain;

public class StockAttributeDecimal
{
    public string AttributeName { get; }
    public decimal? AttributeValue { get; }

    public StockAttributeDecimal(string attributeName, decimal? attributeValue)
    {
        AttributeName = attributeName;
        AttributeValue = attributeValue;
    }
}