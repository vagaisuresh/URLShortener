using System.ComponentModel.DataAnnotations;

namespace URLShortener.API.DataTransferObjects;

public class RoleSaveDto
{
    [Required]
    [StringLength(50)]
    public string? RoleName { get; set; }

    [Required]
    [StringLength(100)]
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }
}