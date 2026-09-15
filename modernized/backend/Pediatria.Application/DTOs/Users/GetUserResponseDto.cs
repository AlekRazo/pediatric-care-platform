namespace Pediatria.Application.DTOs.Users;

public class GetUserResponseDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }

    public List<string> Roles { get; set; } = new List<string>();
}