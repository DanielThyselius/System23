
using Todo.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// We could do this manually, but let's use the built-in routing
// app.MapGet("/health", () => "Healthy");

app.MapHealthChecks("/health");

app.MapGet("api/todos", () =>
{
    var todos = new List<TodoItem>()
    {
        new TodoItem
        {
            Title = "Tvätta bilen",
            Description = "Bilen måste tvättas, vi har en rabattkod på TvättaDinBil i stan.",
            IsComplete = false,
            Assignee = "Daniel"
        },
        new TodoItem
        {
            Title = "Köpa mjölk",
            Description = "Test",
            IsComplete = false,
            Assignee = "Daniel"
        },
        new TodoItem
        {
            Title = "Köpa mjölk",
            Description = "Test",
            IsComplete = false,
            Assignee = "Daniel"
        }
    };
    // TODO: This should be fetched from a database (SQL)
    
    return todos;
});

app.Run();
