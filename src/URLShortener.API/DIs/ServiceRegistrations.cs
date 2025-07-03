using Microsoft.EntityFrameworkCore;
using URLShortener.API.Context;

namespace URLShortener.API.DIs;

public static class ServiceRegistrations
{
    public static void ConfigureSqlContext(this IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("SqlConnection__CleanArchitecture") ?? string.Empty;

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Database connection string is not set in environment variables.");
            
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    }
}