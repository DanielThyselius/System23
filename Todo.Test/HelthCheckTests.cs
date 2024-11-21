using Microsoft.AspNetCore.Mvc.Testing;
using Todo.Api;
using Xunit.Sdk;

namespace Todo.Test;

public class HelthCheckTests : IClassFixture<WebApplicationFactory<ApiMarker>>
{
    private readonly HttpClient _httpClient;
    
    public HelthCheckTests(WebApplicationFactory<ApiMarker> factory)
    {
        _httpClient = factory.CreateClient();
    }
    
    [Fact]
    public async Task HealthCheckReturnsHealthy()
    {
        // Arrange
        // ...
        // Act
        var response = await _httpClient.GetAsync("/health");
        // Assert       
        
        // These two lines do essentially the same thing
        response.EnsureSuccessStatusCode();
        // Assert.True(response.IsSuccessStatusCode);
    }
}