using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(UserRegisterDto userRegisterDto);
    Task<bool> UpdateAsync(int id, UserUpdateDto userUpdateDto);
    Task<bool> DeleteAsync(int id);
}