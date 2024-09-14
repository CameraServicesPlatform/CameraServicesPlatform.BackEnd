namespace CameraServicesPlatform.BackEnd.Common.ConfigurationModel;

public class JWTConfiguration
{
    public string? Key { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
}