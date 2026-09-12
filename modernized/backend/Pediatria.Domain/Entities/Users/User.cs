namespace Pediatria.Domain.Entities.Users;

public sealed class User
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public DateTime? DeactivatedAt { get; set; }
    public Role Role { get; set; } = null!;
    public Physician? Physician { get; set; }
    public Receptionist? Receptionist { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; } = new List<RefreshToken>();
    public ICollection<PasswordReset> PasswordResets { get; } = new List<PasswordReset>();
    public ICollection<PasswordReset> AdminPasswordResets { get; } = new List<PasswordReset>();
    public ICollection<AuditLog> AuditLogs { get; } = new List<AuditLog>();
}