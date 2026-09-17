namespace Pediatria.Domain.Entities.Users;

public sealed class Physician
{
    public Guid UserId { get; set; }
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string ProfessionalLicenseNumber { get; set; } = null!;
    public string EducationalInstitution { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public byte[]? Signature { get; set; }
    
    public User User { get; set; } = null!;
    //public ICollection<Patient> AssignedPatients { get; } = new List<Patient>();
    //public ICollection<Consultation> Consultations { get; } = new List<Consultation>();
    //public ICollection<Prescription> Prescriptions { get; } = new List<Prescription>();
}