using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Todo.Api;
using Todo.Core.Models;

namespace Todo.Test;

public class TodoTests : IClassFixture<WebApplicationFactory<ApiMarker>>
{
    private readonly HttpClient _httpClient;
    
    public TodoTests(WebApplicationFactory<ApiMarker> factory)
    {
        _httpClient = factory.CreateClient();
    }
    
    [Fact]
    public async Task CanGetAllTodos()
    {
        // Arrange

        // Act
        var response = await _httpClient.GetAsync("/api/todos");

        // Assert
        response.EnsureSuccessStatusCode();
        var todos = await response.Content.ReadFromJsonAsync<List<TodoItem>>();
        Assert.Equal(3, todos.Count);
        
        // TODO: Extract into separate tests
        Assert.Equal("Tvätta bilen", todos[0].Title);
        Assert.Equal("Bilen måste tvättas, vi har en rabattkod på TvättaDinBil i stan.", todos[0].Description);
        Assert.False(todos[0].IsComplete);
        Assert.Equal("Daniel", todos[0].Assignee);
    }
}