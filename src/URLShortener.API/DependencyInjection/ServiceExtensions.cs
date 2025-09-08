using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.DependencyInjection;

public static class ServiceExtensions
{
    public static void AddShortUrlSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ShortUrlSettings>(configuration.GetSection("ShortUrlSettings"));
    }

    public static void AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("BlazorCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:5284", "http://localhost:5262")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
    }
}