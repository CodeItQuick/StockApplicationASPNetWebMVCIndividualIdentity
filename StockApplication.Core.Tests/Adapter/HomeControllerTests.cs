using System.Net;

namespace StockApplication.Core.Tests.Adapter;

public class HomeControllerTests : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    
    public HomeControllerTests(TestingWebAppFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task WhenAGameIsCreatedThenItReturns200()
    {
        var response = await _client.GetAsync($"/Home/");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task WhenAShortlistIsRequestedThenItReturns200()
    {
        var response = await _client.GetAsync($"/Home/Shortlist");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task WhenAddingAShortlistedStockThenItReturns200()
    {
        var response = await _client.PutAsync(
            $"/Home/Shortlist/Add/AAPL", 
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "hello", "world" }
            }));
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}