using URLShortener.API.Interfaces;
using URLShortener.API.Services;
using URLShortener.API.Utilities;

namespace URLShortener.API.DependencyInjection;

public static class ApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IShortIdGenerator, ShortIdGenerator>();
        services.AddScoped<IShortUrlService, ShortUrlService>();
    }
}