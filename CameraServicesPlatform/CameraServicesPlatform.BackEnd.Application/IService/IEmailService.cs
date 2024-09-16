namespace CameraServicesPlatform.BackEnd.Application.IService;

public interface IEmailService
{
    public void SendEmail(string recipient, string subject, string body);
}