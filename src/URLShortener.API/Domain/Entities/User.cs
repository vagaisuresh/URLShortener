namespace URLShortener.API.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string EmailAddress { get; set; }
    public required string PasswordHash { get; set; }
    public short RoleId { get; set; }
    public required string MobileNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ProfilePicture { get; set; }
    public bool IsActive { get; set; }
    public bool IsRemoved { get; set; }
    public DateTime CreatedDate { get; set; }
}