using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

namespace Pediatria.Infrastructure.Configurations.Users;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("audit_log", t => t.HasCheckConstraint("CK_audit_log_actions", "[action] IN (N'Acceso', N'Creación', N'Modificación', N'Eliminación')"));
        builder.HasKey(a => a.Id);
        builder.Property(a => a.UserId).IsRequired();
        builder.Property(a => a.Entity).IsRequired().HasMaxLength(100);
        builder.Property(a => a.EntityId).IsRequired();
        builder.Property(a => a.Action).IsRequired().HasMaxLength(30);
        builder.Property(a => a.Timestamp).IsRequired();
    }
}