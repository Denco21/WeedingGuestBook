namespace BlazorMessageWall.Services.EmailService
{
	public interface IEmailService 
	{
		Task SendEmailAsync(EmailMessage message);
	}
}
