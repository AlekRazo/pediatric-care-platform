namespace Pediatria.Application.DTOs.Users;

public class ReceptionistResposeDto : GetUserResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; }

    //

    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
}