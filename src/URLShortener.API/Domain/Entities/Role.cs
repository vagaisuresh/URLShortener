using System.ComponentModel.DataAnnotations.Schema;

namespace URLShortener.API.Domain.Entities;

[Table("UserRole")]
public class Role
{
    public short Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}