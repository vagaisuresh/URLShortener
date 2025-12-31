namespace URLShortener.API.DataTransferObjects;

public class RoleDto
{
    public short Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}