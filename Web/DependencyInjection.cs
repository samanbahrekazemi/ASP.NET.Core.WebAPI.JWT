public static class DependencyInjection
{
    public static IServiceCollection AddGlobals(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllersWithViews();
        services.AddHttpClient();
        services.AddHealthChecks();
        return services;
    }
}

