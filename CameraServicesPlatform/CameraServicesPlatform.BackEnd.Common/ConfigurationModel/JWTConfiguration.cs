namespace CameraServicesPlatform.BackEnd.Common.ConfigurationModel;

public class JWTConfiguration
{
    public string? Key { get; set; }
    public IEnumerable<string> Issuer { get; set; } = new List<string>(); // Change to IEnumerable<string>
    public string? Audience { get; set; }
}