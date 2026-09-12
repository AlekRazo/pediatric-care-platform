namespace Pediatria.Application.DTOs.Users.GetUser;

public class ReceptionistDto : ProfileDto
{
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
}