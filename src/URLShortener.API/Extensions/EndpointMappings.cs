using URLShortener.API.Endpoints;

namespace URLShortener.API.Extensions;

public static class EndpointMappings
{
    public static void MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapRoleEndpoints();
        app.MapShortUrlEndpoints();
    }
}