using System.Net;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

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
        
        var response = await _client.GetAsync($"/Shortlist");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task WhenAddingAShortlistedStockThenItReturns200()
    {
        var response = await _client.PutAsync($"/Shortlist/Add/AAPL", null);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}