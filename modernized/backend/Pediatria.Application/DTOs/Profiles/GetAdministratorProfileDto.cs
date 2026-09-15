namespace Pediatria.Application.DTOs.Users;

public class AdministratorProfileDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
}