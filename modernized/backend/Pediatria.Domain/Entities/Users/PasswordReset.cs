namespace Pediatria.Domain.Entities.Users;

public sealed class PasswordReset
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid UserId { get; set; }
    public Guid AdminId { get; set; }
    public string TempPasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool Used { get; set; }
    
    public User User { get; set; } = null!;
    public User Admin { get; set; } = null!;
}