namespace Pediatria.Application.DTOs.Users.Login;

public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public Guid UserId { get; set; }
}