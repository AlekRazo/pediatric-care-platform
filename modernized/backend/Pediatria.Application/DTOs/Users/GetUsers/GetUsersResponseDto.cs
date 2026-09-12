namespace Pediatria.Application.DTOs.Users.GetUsers;

public class GetUsersResponseDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int RoleId { get; set; }
}