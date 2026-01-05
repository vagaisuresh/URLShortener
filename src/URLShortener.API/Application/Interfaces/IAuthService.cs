using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Application.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(LoginRequest loginRequest);
}