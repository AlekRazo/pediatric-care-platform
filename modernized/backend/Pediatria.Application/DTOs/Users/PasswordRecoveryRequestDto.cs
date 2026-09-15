namespace Pediatria.Application.DTOs.Users;

public class PasswordRecoveryRequestDto
{
    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}