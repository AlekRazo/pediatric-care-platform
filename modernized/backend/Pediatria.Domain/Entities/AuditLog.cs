using Pediatria.Domain.Entities.Users;

namespace Pediatria.Domain.Entities;

public sealed class AuditLog
{
    public long Id { get; set; }
    public Guid? UserId { get; set; }
    public string Entity { get; set; } = null!;
    public string? EntityId { get; set; }
    public string Action { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public string? IpAddress { get; set; }
    public string? Details { get; set; }
    public User? User { get; set; }
}