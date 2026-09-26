using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Pediatria.Application.Interfaces.Services;

namespace Pediatria.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendPassowrdRecoveryEmailAsync(string toEmail, string resetToken)
    {
        var frontendUrl = _configuration["Frontend:Url"] ?? throw new InvalidOperationException("Frontend:Url no está configurado.");
        var resetUrl = $"{frontendUrl}/reset-password?token={Uri.EscapeDataString(resetToken)}";
        var subject = "Recuperación de contraseña";
        var button = GenerateHtmlButton(resetUrl, "#ffffff", "#4f48e0", "Restablecer contraseña");
        var text = """
            Hemos recibido una solicitud para restablecer su contraseña. Haga click en el enlace para crear una nueva contraseña:

            {button}

            Si no puede hacer click en el botón, copie y pegue el siguiente enlace al navegador:
            {resetUrl}

            El enlace caducará en 30 minutos.

            Si no ha sido usted quien envió la solicitud, no haga caso a este correo.
            """;

        text = text.Replace("{button}", button).Replace("{resetUrl}", resetUrl);

        var body = GetEmailHtmlBody("Recuperación de contraseña", text);
        
        await SendHtmlEmail(toEmail, subject, body);
    }

    private async Task SendHtmlEmail(string toEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Pediatria App", _configuration["Email:Email"]!));
        message.To.Add(new MailboxAddress(toEmail, toEmail));
        message.Subject = subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = body
        };

        using var client = new SmtpClient();

        await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_configuration["Email:Email"]!, _configuration["Email:Password"]!);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);

    }

    private string GetEmailHtmlBody(string title, string text)
    {
        var htmlText = "<p>" + text.Replace(Environment.NewLine + Environment.NewLine, "</p><p>").Replace(Environment.NewLine, "<br />").Replace("</p><p>", "</p>" + Environment.NewLine + "<p>") + "</p>";
        var html = """
        <!DOCTYPE html>
        <html lang="es">
        <head>
            <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
            <title>Recuperación de contraseña</title>
            <link rel="preconnect" href="https://fonts.gstatic.com">
            <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
        </head>
        <body style="padding: 0; margin: 0; -webkit-font-smoothing:antialiased; background-color:#ffffff; -webkit-text-size-adjust:none;">
            <!--Main Parent Table -->
            <table width="100%" border="0" cellpadding="0" direction="ltr" bgcolor="#ffffff" cellspacing="0" role="presentation" style="width: 640px; min-width: 640px; margin:0 auto 0 auto;">
                <tbody>
                    <!--Top Header Starts Here -->
                    <tr>
                        <td align="center" style="color:#ffffff;padding:30px 40px 30px 40px;font-family: 'Lato', Arial, Helvetica, sans-serif;font-weight:800;font-size:24px;-webkit-font-smoothing:antialiased;line-height:1.2;" role="presentation" bgcolor="#4f48e0">
                            PEDIATRIA APP
                        </td>
                    </tr>
                    <!--Top Header Ends Here -->
                    <!--Content Starts Here -->
                    <tr>
                        <td align="left" style="color:#45535C;padding:60px 40px 0 40px;font-family: 'Lato', Arial, Helvetica, sans-serif;font-weight:800;font-size:24px;-webkit-font-smoothing:antialiased;line-height:1.2;" class="table-container mobile-title">
                            {title}
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left" style="color:#5a5a5a;padding:20px 40px 60px 40px;font-family: 'Lato', Arial, Helvetica, sans-serif;font-weight:normal;font-size:14px;-webkit-font-smoothing:antialiased;line-height:1.4;" class="table-container">
                            {text}
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="color:#444444; padding:30px 40px 30px 40px; font-family: 'Lato', Arial, Helvetica, sans-serif; font-size:14px; line-height:22px; text-align:center;border:none;font-weight:bold;" bgcolor="#f1f1f1">
                            Este es un correo automatizado. Por favor no responda a este mensaje. 
                        </td>
                    </tr>
                </tbody>
            <!--Main Parent Table Ends Here -->
            </table>
        </body>
        </html>
        """;

        return html.Replace("{title}", title).Replace("{text}", htmlText);
    }

    private string GenerateHtmlButton(string url, string hexColor, string hexBgColor, string text)
    {
        //color #ffffff
        //bgColor #ff5746
        var btnHtml = """<a href="{url}" style="background-color: {hexBgColor}; color: {hexColor}; display: inline-block;font-family: 'Lato', Arial, Helvetica, sans-serif; font-size: 16px; line-height: 20px; text-align: center; font-weight: bold; text-decoration: none; padding: 20px 25px; min-width: 150px; -webkit-text-size-adjust: none;">{text}</a>""";
        return btnHtml.Replace("{url}", url).Replace("{hexColor}", hexColor).Replace("{hexBgColor}", hexBgColor).Replace("{text}", text);
    }
}