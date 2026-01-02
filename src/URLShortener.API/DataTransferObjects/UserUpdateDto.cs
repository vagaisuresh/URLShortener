using System.ComponentModel.DataAnnotations;

namespace URLShortener.API.DataTransferObjects;

public class UserUpdateDto
{
    [Required]
    [StringLength(50)]
    public string FullName { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string MobileNumber { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    [StringLength(50)]
    public string? ProfilePicture { get; set; }
}