using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Models;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IWebApiConfig, WebApiConfig>();
        services.Configure<WebApiConfig>(config.GetSection("WebApi"));
        return services;
    }
}

