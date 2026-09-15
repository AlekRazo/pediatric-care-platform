namespace Pediatria.Application.DTOs.Users;

public class RegisterPhysicianDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }

    //

    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string ProfessionalLicenseNumber { get; set; } = null!;
    public string EducationalInstitution { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public byte[]? Signature { get; set; }
}