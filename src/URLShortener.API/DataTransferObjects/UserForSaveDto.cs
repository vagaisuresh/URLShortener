using System.ComponentModel.DataAnnotations;

namespace URLShortener.API.DataTransferObjects;

public class UserForSaveDto
{
    [Required]
    [StringLength(50)]
    public string FullName { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string EmailAddress { get; set; } = null!;

    public short RoleId { get; set; }

    [Required]
    [StringLength(15)]
    public string MobileNumber { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    [StringLength(50)]
    public string? ProfilePicture { get; set; }
    
    public bool IsActive { get; set; }
}