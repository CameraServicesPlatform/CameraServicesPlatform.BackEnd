namespace CameraServicesPlatform.BackEnd.Common.DTO.Request;
public class UpdateAccountRequestDTO
{
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
}