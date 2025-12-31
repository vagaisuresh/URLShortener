using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllAsync();
    Task<RoleDto?> GetByIdAsync(short id);
    Task<RoleDto> CreateAsync(RoleSaveDto roleSaveDto);
    Task<bool> UpdateAsync(short id, RoleSaveDto roleSaveDto);
    Task<bool> DeleteAsync(short id);
}