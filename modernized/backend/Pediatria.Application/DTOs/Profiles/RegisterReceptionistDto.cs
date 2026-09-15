namespace Pediatria.Application.DTOs.Users;

public class RegisterReceptionistDto
{
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
}