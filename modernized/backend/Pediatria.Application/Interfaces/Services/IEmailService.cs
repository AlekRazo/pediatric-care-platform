namespace Pediatria.Application.Interfaces.Services;

public interface IEmailService
{
    Task SendPassowrdRecoveryEmailAsync(string toEmail, string resetToken);
}