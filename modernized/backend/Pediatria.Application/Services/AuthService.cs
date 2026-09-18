using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;
using Pediatria.Application.Interfaces.Repositories;
using Pediatria.Application.Interfaces.Services;
using Pediatria.Domain.Exceptions;

namespace Pediatria.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IConfiguration _configuration;

    public AuthService(ITokenRepository tokenRepository, IUsersRepository usersRepository, IConfiguration configuration)
    {
        _tokenRepository = tokenRepository;
        _usersRepository = usersRepository;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> Login(AuthRequestDto request)
    {
        var user = await _usersRepository.GetByUsernameAsync(request.Username);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedException("El usuario o contraseña son incorrectos");
        }

        var jwtToken = _tokenRepository.CreateJWTToken(user);

        return new AuthResponseDto
        {
            UserId = user.Id,
            Token = jwtToken,
            Email = user.Email,
            IsActive = user.Active,
            Roles = user.UserRoles.Select(x => x.Role.Name).ToList()
        };
    }

    public Task<bool> Logout()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RecoverPassword(PasswordRecoveryRequestDto request)
    {
        var user = await _usersRepository.GetByUsernameAsync(request.Username);

        if (user is null || request.Email != user.Email)
        {
            throw new UnauthorizedException("El usuario o correo electrónico son incorrectos");
        }

        //Generar nueva contraseña

        //Crear cuenta de correo específica para producción
        var fromAddress = new MailAddress(_configuration["Email:Email"]!, "From Name");
        var toAddress = new MailAddress(user.Email, "To Name");

        string fromPassword = _configuration["Email:Password"]!;
        string subject = "Correo de recuperación de contraseña";
        string body = "";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }

        return true;
    }
}