using URLShortener.API.Interfaces;
using URLShortener.API.Services;
using URLShortener.API.Utilities;

namespace URLShortener.API.DIs;

public static class DependencyBindings
{
    public static void ConfigureToBindDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IShortIdGenerator, ShortIdGenerator>();
        services.AddScoped<IShortUrlService, ShortUrlService>();
    }
}