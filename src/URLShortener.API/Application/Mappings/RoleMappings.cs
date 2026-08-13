using URLShortener.API.DataTransferObjects;
using URLShortener.API.Domain.Entities;

namespace URLShortener.Application.Mappings;

public static class RoleMappings
{
    public static Role ToEntity(this RoleSaveDto saveDto)
    {
        return new Role
        {
            Name = saveDto.Name,
            Description = saveDto.Description,
            IsActive = saveDto.IsActive
        };
    }

    public static RoleDto ToDto(this Role role)
    {
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
            IsActive = role.IsActive
        };
    }
}