namespace CameraServicesPlatform.BackEnd.Common.DTO.Request;
public class ForgotPasswordDTO
{
    public string Email { get; set; } = null!;
    public string? RecoveryCode { get; set; }
    public string? NewPassword { get; set; }
}
