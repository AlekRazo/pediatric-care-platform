namespace Pediatria.Application.DTOs.Users.GetUsers;

public class PhysicianDto : ProfileDto
{
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string ProfessionalLicenseNumber { get; set; } = null!;
    public string EducationalInstitution { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public byte[]? Signature { get; set; }
}