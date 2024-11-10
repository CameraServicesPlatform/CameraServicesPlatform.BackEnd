using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.ConfigurationModel;
using CameraServicesPlatform.BackEnd.Common.Utils;
using MailKit.Security;
using MimeKit;

namespace CameraServicesPlatform.BackEnd.Application.Service;

public class EmailService : GenericBackendService, IEmailService
{
    private readonly EmailConfiguration _emailConfiguration;
    private readonly BackEndLogger _logger;

    public EmailService(BackEndLogger logger, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _logger = logger;
        _emailConfiguration = Resolve<EmailConfiguration>()!;
    }

    public void SendEmail(string recipient, string subject, string body)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Camera service platform Company", _emailConfiguration.User));
            message.To.Add(new MailboxAddress("Khách hàng", recipient));
            message.Subject = subject;
            message.Importance = MessageImportance.High;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate(_emailConfiguration.User, _emailConfiguration.ApplicationPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, this);
        }
    }

    public async Task SendEmailAsync(string recipient, string subject, string body)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Camera service platform Company", _emailConfiguration.User));
            message.To.Add(new MailboxAddress("Khách hàng", recipient));
            message.Subject = subject;
            message.Importance = MessageImportance.High;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailConfiguration.User, _emailConfiguration.ApplicationPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, this);
        }
    }

    public async Task SendEmailWithAttachments(string recipient, string subject, string body, List<string> attachmentFilePaths)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Camera Service Platform", _emailConfiguration.User));
            message.To.Add(new MailboxAddress("Khách hàng", recipient));
            message.Subject = subject;
            message.Importance = MessageImportance.High;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body // Set email body as HTML
            };

            // Add attachments if any
            foreach (var filePath in attachmentFilePaths)
            {
                if (File.Exists(filePath)) // Ensure the file exists before attaching
                {
                    var attachment = new MimePart("application", "octet-stream")
                    {
                        Content = new MimeContent(File.OpenRead(filePath)),
                        FileName = Path.GetFileName(filePath)
                    };
                    bodyBuilder.Attachments.Add(attachment); // Add attachment to email body
                }

            }

            message.Body = bodyBuilder.ToMessageBody(); // Set email body with attachments

            // Send email via SMTP client
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate(_emailConfiguration.User, _emailConfiguration.ApplicationPassword);
                client.Send(message); // Send email
                client.Disconnect(true); // Disconnect after sending
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, this); // Log any error during the email sending process
        }
    }
}
