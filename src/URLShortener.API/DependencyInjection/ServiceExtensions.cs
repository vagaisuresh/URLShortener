namespace URLShortener.API.DependencyInjection;

public static class ServiceExtensions
{
    public static void AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("BlazorCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:5284")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
    }
}