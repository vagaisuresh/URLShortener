namespace URLShortener.API.DataTransferObjects;

public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public short RoleId { get; set; }
    public string? MobileNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ProfilePicture { get; set; }
    public bool IsActive { get; set; }
}