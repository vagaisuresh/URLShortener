using Microsoft.AspNetCore.Mvc;
using URLShortener.API.Application.Interfaces;
using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Endpoints;

public static class ShortUrlEndpoints
{
    public static void MapShortUrlEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/short-urls", async ([FromServices] IShortUrlService service)
            => await service.GetShortUrlsAsync());

        app.MapGet("/short-urls/{id}", async (int id, [FromServices] IShortUrlService service)
            => await service.GetShortUrlAsync(id));

        app.MapGet("/short-urls/short-id/{shortId}", async (string shortId, [FromServices] IShortUrlService service)
            => await service.GetShortUrlByShortIdAsync(shortId));
        
        app.MapPost("/short-urls", async ([FromBody] ShortUrlRequest shortUrlResponse, [FromServices] IShortUrlService service)
            => await service.CreateShortUrlAsync(shortUrlResponse));

        app.MapPut("/short-urls/{id}", async (int id, [FromBody] ShortUrlRequest shortUrlRequest, [FromServices] IShortUrlService service)
            => await service.UpdateShortUrlAsync(id, shortUrlRequest));

        app.MapDelete("/short-urls/{id}", async (int id, [FromServices] IShortUrlService service)
            => await service.DeleteShortUrlAsync(id));
    }
}