namespace CameraServicesPlatform.BackEnd.Common.DTO.Request;

public class ChangePasswordDTO
{
    public string Email { get; set; } = null!;
    public string OldPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}