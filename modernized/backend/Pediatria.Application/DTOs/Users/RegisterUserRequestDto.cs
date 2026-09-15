namespace Pediatria.Application.DTOs.Users;

public class RegisterUserRequestDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
}