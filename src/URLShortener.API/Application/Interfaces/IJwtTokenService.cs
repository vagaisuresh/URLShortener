namespace URLShortener.API.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateJwtToken(string fullName, short roleId);
}