using Microsoft.Extensions.DependencyInjection;
using TodoCleanArch.Application.Interfaces.Services;
using TodoCleanArch.Application.Services;

namespace TodoCleanArch.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}

