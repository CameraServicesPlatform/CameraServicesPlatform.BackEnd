namespace CameraServicesPlatform.BackEnd.Application.IService;

public interface IEmailService
{
    public void SendEmail(string recipient, string subject, string body);

    Task SendEmailAsync(string recipient, string subject, string body);
    Task SendEmailWithAttachments(string recipient, string subject, string body, List<string> attachmentFilePaths);


}