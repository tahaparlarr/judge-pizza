using JudgePizzaApp.Models.ViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace JudgePizzaApp.Services;

public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int Port { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Password { get; set; }
    public string RecipientEmail { get; set; }
}

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
    Task SendContactFormAsync(ContactFormViewModel model, string recipientEmail);
}

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> settings)
    {
        _emailSettings = settings.Value;
    }
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var email = new MimeMessage();

        email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;

        var builder = new BodyBuilder
        {
            HtmlBody = body
        };
        email.Body = builder.ToMessageBody();

        using (var smtp = new SmtpClient())
        {
            await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }

    public async Task SendContactFormAsync(ContactFormViewModel model, string recipientEmail)
    {
        string subject = $"Yeni İletişim Mesajı - {model.Name} {model.Surname}";
        string body = $@"
        <h2>Yeni mesajınız var:</h2>
        <p><strong>İsim:</strong> {model.Name}</p>
        <p><strong>Soyisim:</strong> {model.Surname}</p>
        <p><strong>E-Posta:</strong> {model.Email}</p>
        <p><strong>Mesaj:</strong></p>
        <p>{model.Message}</p>";

        await SendEmailAsync(recipientEmail, subject, body);
    }
}