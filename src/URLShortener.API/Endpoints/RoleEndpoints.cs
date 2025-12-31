using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using URLShortener.API.Application.Interfaces;
using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Endpoints;

public static class RoleEndpoints
{
    public static void MapRoleEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/roles", async ([FromServices] IRoleService service) =>
        {
            var roleDtos = await service.GetAllAsync();
            return Results.Ok(roleDtos);
        });

        app.MapGet("/roles/{id}", async (short id, [FromServices] IRoleService service) =>
        {
            if (id <= 0)
                return Results.BadRequest("Invalid id provided.");
            
            var roleDto = await service.GetByIdAsync(id);
            return roleDto is null ? Results.NotFound() : Results.Ok(roleDto);
        })
        .WithName("GetRoleById");

        app.MapPost("/roles", async ([FromBody] RoleSaveDto roleSaveDto, [FromServices] IRoleService service) =>
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(roleSaveDto);

            if (!Validator.TryValidateObject(roleSaveDto, validationContext, validationResults, true))
                return Results.BadRequest("Invalid model received.");
            
            try
            {
                var roleDto = await service.CreateAsync(roleSaveDto);
                return Results.CreatedAtRoute("GetRoleById", new { id = roleDto.Id }, roleDto);
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });

        app.MapPut("/roles/{id}", async (short id, [FromBody] RoleSaveDto roleSaveDto, [FromServices] IRoleService service) =>
        {
            if (id <= 0)
                return Results.BadRequest("Invalid id provided.");

            try
            {
                bool updated = await service.UpdateAsync(id, roleSaveDto);
                return updated ? Results.NoContent() : Results.NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });

        app.MapDelete("/roles/{id}", async (short id, [FromServices] IRoleService service) =>
        {
            if (id <= 0)
                return Results.BadRequest("Invalid id provided.");
                
            bool deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}