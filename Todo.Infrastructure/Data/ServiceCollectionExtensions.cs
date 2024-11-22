using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Infrastructure.Data;

public static class ServiceCollectionExtensions
{
    public static void AddTodoDbContext(this IServiceCollection services)
    {
        services.AddDbContext<TodoDbContext>(options =>
        {
            options.UseInMemoryDatabase("TodoDb");
        });
    }
}