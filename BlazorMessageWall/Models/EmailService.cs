using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using BlazorMessageWall.Services.EmailService;
using Microsoft.Extensions.Options;

public class EmailService : IEmailService
{
	private readonly SmtpSettings _smtpSettings;

	public EmailService(IOptions<SmtpSettings> smtpSettings)
	{
		_smtpSettings = smtpSettings.Value;
	}

	public async Task SendEmailAsync(EmailMessage message)
	{
		var email = new MimeMessage();
		email.Sender = MailboxAddress.Parse(_smtpSettings.Username);
		email.To.Add(MailboxAddress.Parse(message.ToEmail));
		email.Subject = message.Subject;
		email.Body = new TextPart(TextFormat.Plain) { Text = message.Body };

		using var smtp = new MailKit.Net.Smtp.SmtpClient();
		await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTls);
		await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
		await smtp.SendAsync(email);
		await smtp.DisconnectAsync(true);
	}
}
