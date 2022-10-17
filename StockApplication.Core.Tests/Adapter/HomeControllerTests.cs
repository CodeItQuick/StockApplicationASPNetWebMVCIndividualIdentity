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
        var response = await _client.PostAsync($"/Shortlist/Add/AAPL/1", null);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task WhenDeletingAShortlistedStockThenItReturns200()
    {
        await _client.PostAsync($"/Shortlist/Add/HPR/1", null);
        
        var response = await _client.PostAsync(
            $"/Shortlist/Remove/HPR", 
            null);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task WhenRetrievingSettingsPageReturns200()
    {
        var response = await _client.GetAsync("/Settings");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}