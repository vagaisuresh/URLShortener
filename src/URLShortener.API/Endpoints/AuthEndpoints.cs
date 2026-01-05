using Microsoft.AspNetCore.Mvc;
using URLShortener.API.Application.Interfaces;
using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/login", async (LoginRequest loginRequest, [FromServices] IAuthService service) =>
        {
            try
            {
                string token = await service.LoginAsync(loginRequest);

                if (token == null || token == "")
                    return Results.Unauthorized();

                return Results.Ok(new { Token = token });
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });
    }
}