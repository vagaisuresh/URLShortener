using URLShortener.API.Application.Interfaces;
using URLShortener.API.Application.Services;
using URLShortener.API.Services;
using URLShortener.API.Utilities;

namespace URLShortener.API.DependencyInjection;

public static class ApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IShortIdGenerator, ShortIdGenerator>();
        services.AddScoped<IShortUrlService, ShortUrlService>();

        services.AddScoped<IRoleService, RoleService>();
    }
}