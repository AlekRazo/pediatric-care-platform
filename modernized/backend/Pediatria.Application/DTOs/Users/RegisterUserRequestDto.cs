namespace Pediatria.Application.DTOs.Users;

public class RegisterUserRequestDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int RoleId { get; set; }

    public T? Profile { get; set; }
}