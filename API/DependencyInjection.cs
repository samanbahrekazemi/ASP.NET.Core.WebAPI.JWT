public static class DependencyInjection
{
    public static IServiceCollection AddGlobals(this IServiceCollection services, IConfiguration config)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });


        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "redis:6379"; // redis is the container name of the redis service. 6379 is the default port
            options.InstanceName = "RedisInstance";
        });


        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        return services;
    }
}

