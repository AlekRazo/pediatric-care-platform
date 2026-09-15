namespace Pediatria.Application.DTOs.Users;

public class UpdateUserRequestDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool? Active { get; set; }

    public List<string> Roles { get; set; } = new List<string>();
}