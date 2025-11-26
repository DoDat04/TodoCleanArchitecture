using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoCleanArch.Application.Interfaces;
using TodoCleanArch.Infrastructure.Context;
using TodoCleanArch.Infrastructure.Repositories;

namespace TodoCleanArch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TodoListContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                options.UseSqlServer(connectionString);
            }
            else
            {
                options.UseInMemoryDatabase("TodoDb");
            }
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

