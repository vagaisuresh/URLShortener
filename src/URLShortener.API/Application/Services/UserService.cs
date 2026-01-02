using Microsoft.EntityFrameworkCore;
using URLShortener.API.Application.Interfaces;
using URLShortener.API.DataTransferObjects;
using URLShortener.API.Domain.Entities;
using URLShortener.API.Persistence.Context;

namespace URLShortener.API.Application.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _context.Users
            .AsNoTracking()
            .ToListAsync();

        var userDtos = users.Select(x => new UserDto
        {
            Id = x.Id,
            FullName = x.FullName,
            EmailAddress = x.EmailAddress,
            RoleId = x.RoleId,
            MobileNumber = x.MobileNumber,
            DateOfBirth = x.DateOfBirth,
            ProfilePicture = x.ProfilePicture,
            IsActive = x.IsActive
        }).ToList();

        return userDtos;
    }

    public async Task<UserDto?> GetByIdAsync(short id)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        if (user is null)
            return null;
        
        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            EmailAddress = user.EmailAddress,
            RoleId = user.RoleId,
            MobileNumber = user.MobileNumber,
            DateOfBirth = user.DateOfBirth,
            ProfilePicture = user.ProfilePicture,
            IsActive = user.IsActive
        };
    }

    public async Task<UserDto> CreateAsync(UserRegisterDto userRegisterDto)
    {
        if (await _context.Users.AnyAsync(a => a.EmailAddress == userRegisterDto.EmailAddress))
            throw new InvalidOperationException("Email Address already registered.");
        
        var user = new User
        {
            FullName = userRegisterDto.FullName,
            EmailAddress = userRegisterDto.FullName,
            PasswordHash = userRegisterDto.Password,
            RoleId = 3,                                         // Customer - directly assigned
            MobileNumber = userRegisterDto.MobileNumber,
            DateOfBirth = userRegisterDto.DateOfBirth,
            ProfilePicture = userRegisterDto.ProfilePicture,
            IsActive = true,
            IsDeleted = false,
            CreatedBy = 0,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            EmailAddress = user.EmailAddress,
            RoleId = user.RoleId,
            MobileNumber = user.MobileNumber,
            DateOfBirth = user.DateOfBirth,
            ProfilePicture = user.ProfilePicture,
            IsActive = user.IsActive
        };
    }

    public Task<bool> UpdateAsync(short id, UserUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(short id)
    {
        throw new NotImplementedException();
    }
}