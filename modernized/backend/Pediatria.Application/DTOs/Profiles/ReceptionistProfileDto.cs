namespace Pediatria.Application.DTOs.Profiles;

public class ReceptionistProfileDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
}