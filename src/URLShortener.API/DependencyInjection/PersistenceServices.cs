using Microsoft.EntityFrameworkCore;
using URLShortener.API.Context;

namespace URLShortener.API.DependencyInjection;

public static class PersistenceServices
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
    }

    public static void AddAppDbContext(this IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("SqlConnection__CleanArchitecture") ?? string.Empty;

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Database connection string is not set in environment variables.");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    }
}