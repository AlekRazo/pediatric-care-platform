using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Pediatria.Application.Interfaces.Services;

namespace Pediatria.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendPassowrdRecoveryEmailAsync(string toEmail, string temporaryPassword)
    {
        //Crear cuenta de correo específica para producción
        var fromAddress = new MailAddress(_configuration["Email:Email"]!, "From Name");
        var toAddress = new MailAddress(toEmail, "To Name");

        string fromPassword = _configuration["Email:Password"]!;
        string subject = "Correo de recuperación de contraseña";
        string body = $"Su contraseña temporal es: { temporaryPassword }. Expira en 24 horas.";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        };
        
        await smtp.SendMailAsync(message);
    }
}