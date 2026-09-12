namespace Pediatria.Application.DTOs.Users.GetUser;

public class GetUsersResponseDto
 {
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; }

    public ProfileDto Profile { get; set; } = null!;
 }