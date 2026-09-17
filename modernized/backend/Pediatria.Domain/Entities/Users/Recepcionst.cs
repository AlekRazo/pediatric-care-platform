namespace Pediatria.Domain.Entities.Users;

public sealed class Receptionist
{
    public Guid UserId { get; set; }
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    
    public User User { get; set; } = null!;
}