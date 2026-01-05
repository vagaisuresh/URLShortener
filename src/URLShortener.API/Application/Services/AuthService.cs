using Microsoft.EntityFrameworkCore;
using URLShortener.API.Application.Interfaces;
using URLShortener.API.DataTransferObjects;
using URLShortener.API.Persistence.Context;

namespace URLShortener.API.Application.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(AppDbContext context, IConfiguration configuration, IJwtTokenService jwtTokenService)
    {
        _context = context;
        _configuration = configuration;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.EmailAddress == loginRequest.EmailAddress);
        
        if (user is null)
            throw new InvalidOperationException("User not found for the provided email address.");
        
        if (BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash) == false)
            throw new InvalidOperationException("Invalid email or password.");

        var token = _jwtTokenService.GenerateJwtToken(user.FullName, user.RoleId);
        return token;
    }
}