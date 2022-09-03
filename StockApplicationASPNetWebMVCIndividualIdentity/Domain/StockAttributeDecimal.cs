namespace StockApplication.Core.Tests.Domain;

public class StockAttributeDecimal
{
    private readonly string _attributeName;
    private readonly decimal _attributeValue;

    public StockAttributeDecimal(string attributeName, decimal attributeValue)
    {
        _attributeName = attributeName;
        _attributeValue = attributeValue;
    }
}