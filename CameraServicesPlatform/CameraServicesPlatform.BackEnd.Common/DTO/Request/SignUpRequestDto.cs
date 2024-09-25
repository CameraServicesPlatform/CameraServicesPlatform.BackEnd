using CameraServicesPlatform.BackEnd.Domain.Enum;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Request;
public class SignUpRequestDTO
{
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; } = null!;
}