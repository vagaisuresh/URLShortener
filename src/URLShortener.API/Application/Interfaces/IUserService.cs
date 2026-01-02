using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(short id);
    Task<UserDto> CreateAsync(UserRegisterDto userRegisterDto);
    Task<bool> UpdateAsync(short id, UserUpdateDto userUpdateDto);
    Task<bool> DeleteAsync(short id);
}