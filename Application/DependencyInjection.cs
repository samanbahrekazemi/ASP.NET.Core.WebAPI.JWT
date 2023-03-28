using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ICategoryService, CategoryService>();

        return services;
    }
}

