namespace Pediatria.Application.DTOs.Users;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<string> Roles { get; set; } = new List<string>();
}