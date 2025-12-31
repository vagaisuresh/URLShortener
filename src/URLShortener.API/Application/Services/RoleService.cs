using Microsoft.EntityFrameworkCore;
using URLShortener.API.Application.Interfaces;
using URLShortener.API.DataTransferObjects;
using URLShortener.API.Domain.Entities;
using URLShortener.API.Persistence.Context;

namespace URLShortener.API.Application.Services;

public class RoleService : IRoleService
{
    private readonly AppDbContext _context;

    public RoleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoleDto>> GetAllAsync()
    {
        var roles = await _context.Roles
            .AsNoTracking()
            .ToListAsync();
        
        var roleDtos = roles.Select(x => new RoleDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            IsActive = x.IsActive
        }).ToList();

        return roleDtos;
    }

    public async Task<RoleDto?> GetByIdAsync(short id)
    {
        var role = await _context.Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        if (role == null)
            return null;
        
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
            IsActive = role.IsActive
        };
    }

    public async Task<RoleDto> CreateAsync(RoleSaveDto roleSaveDto)
    {
        if (await _context.Roles.AnyAsync(e => e.Name == roleSaveDto.Name))
            throw new InvalidOperationException("Role name already exists.");

        // CREATE UNIQUE INDEX IX_Role_Name ON Role(Name);
        // This guarantees no duplicates, even if multiple services or apps write to the table.
        
        var role = new Role
        {
            Name = roleSaveDto.Name,
            Description = roleSaveDto.Description,
            IsActive = roleSaveDto.IsActive,
            IsDeleted = false
        };

        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();

        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
            IsActive = role.IsActive
        };
    }

    public async Task<bool> UpdateAsync(short id, RoleSaveDto roleSaveDto)
    {
        if (await _context.Roles.AnyAsync(e => e.Name == roleSaveDto.Name && e.Id != id))
            throw new InvalidOperationException("Role name already exists.");

        var existingRole = await _context.Roles.FindAsync(id);

        if (existingRole is null)
            return false;
        
        existingRole.Name = roleSaveDto.Name;
        existingRole.Description = roleSaveDto.Description;
        existingRole.IsActive = roleSaveDto.IsActive;

        _context.Roles.Update(existingRole);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(short id)
    {
        var existingRole = await _context.Roles.FindAsync(id);

        if (existingRole is null)
            return false;
        
        _context.Roles.Remove(existingRole);
        await _context.SaveChangesAsync();
        return true;
    }
}