namespace Pediatria.Application.DTOs.Profiles;

public class RegisterReceptionistDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
}