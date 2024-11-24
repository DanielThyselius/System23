using Microsoft.EntityFrameworkCore;
using Todo.Core.Models;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> Todos { get; set; }
    
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedDatabase(modelBuilder);
    }
    
    private static void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem
            {
                Id = 1,
                Title = "Tvätta bilen",
                Description = "Bilen måste tvättas, vi har en rabattkod på TvättaDinBil i stan.",
                IsComplete = false,
                Assignee = "Daniel"
            },
            new TodoItem
            {
                Id = 2,
                Title = "Köpa mjölk",
                Description = "Test",
                IsComplete = false,
                Assignee = "Daniel"
            },
            new TodoItem
            {
                Id = 3,
                Title = "Köpa mjölk",
                Description = "Test",
                IsComplete = false,
                Assignee = "Daniel"
            });
    }
}