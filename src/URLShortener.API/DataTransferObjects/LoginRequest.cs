using System.ComponentModel.DataAnnotations;

namespace URLShortener.API.DataTransferObjects;

public record LoginRequest(
    [Required(ErrorMessage = "Email Address is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    string EmailAddress,

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be at least 6 and up to 16 characters")]
    string Password
);