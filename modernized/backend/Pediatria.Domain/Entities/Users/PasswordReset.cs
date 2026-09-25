namespace Pediatria.Domain.Entities.Users;

public sealed class PasswordReset
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? RequestedByUserd { get; set; }
    public string TokenHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime? UsedAt { get; set; }
    
    public User User { get; set; } = null!;
}