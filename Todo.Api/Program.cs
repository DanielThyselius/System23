using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

// Create path for database
var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = System.IO.Path.Join(path, "todo.db");

builder.Services.AddDbContext<TodoDbContext>(options => { options.UseSqlite($"Data Source={dbPath}"); });

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

// TODO: This should probably not be in Program.cs
app.MapGet("api/todos", (TodoDbContext context) =>
{
    var todos = context.Todos.ToListAsync();
    return todos;
});

app.Run();