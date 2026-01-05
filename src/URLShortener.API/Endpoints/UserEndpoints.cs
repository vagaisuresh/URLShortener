using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using URLShortener.API.Application.Interfaces;
using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/users", async ([FromServices] IUserService userService) => 
        {
            var userDtos = await userService.GetAllAsync();
            return Results.Ok(userDtos);
        });

        app.MapGet("/users/{id}", async (short id, IUserService userService) =>
        {
            if (id <= 0)
                return Results.BadRequest("Invalid id provided.");
            
            var userDto = await userService.GetByIdAsync(id);
            return userDto is null ? Results.NotFound() : Results.Ok(userDto);
        })
        .WithName("GetUserById");

        app.MapPost("/users", async (UserRegisterDto userRegisterDto, IUserService userService) =>
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRegisterDto);

            if (!Validator.TryValidateObject(userRegisterDto, validationContext, validationResults, true))
                return Results.BadRequest("Invalid model received.");
            
            try
            {
                var userDto = await userService.CreateAsync(userRegisterDto);
                return Results.CreatedAtRoute("GetUserById", new { id = userDto.Id }, userDto);
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });

        app.MapPut("/users/{id}", async (short id, UserUpdateDto userUpdateDto, IUserService service) =>
        {
            if (id <= 0)
                return Results.BadRequest("Invalid id provided.");
            
            try
            {
                bool updated = await service.UpdateAsync(id, userUpdateDto);
                return updated ? Results.NoContent() : Results.NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });

        app.MapDelete("/users/{id}", async (short id, IUserService service) =>
        {
            if (id <= 0)
                return Results.BadRequest("Invalid id provided.");
            
            try
            {
                bool deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });
    }
}