using URLShortener.API.DataTransferObjects;
using URLShortener.API.Domain.Entities;

namespace URLShortener.Application.Mappings;

public static class UserMappings
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            EmailAddress = user.EmailAddress,
            RoleId = user.RoleId,
            MobileNumber = user.MobileNumber,
            DateOfBirth = user.DateOfBirth,
            ProfilePicture = user.ProfilePicture,
            IsActive = user.IsActive
        };
    }
}