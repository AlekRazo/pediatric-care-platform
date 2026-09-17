using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

namespace Pediatria.Infrastructure.Configurations.Users;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("audit_log", t => t.HasCheckConstraint("CK_audit_log_action", "[action] IN (N'Acceso', N'Creación', N'Modificación', N'Eliminación')"));
        builder.HasKey(a => a.Id).HasName("PK_audit_log");

        builder.Property(a => a.Entity).HasMaxLength(50).IsRequired();
        builder.Property(a => a.EntityId).HasMaxLength(50);
        builder.Property(a => a.Action).HasMaxLength(30).IsRequired();
        builder.Property(a => a.Timestamp).HasDefaultValueSql("SYSUTCDATETIME()");
        builder.Property(a => a.IpAddress).HasMaxLength(45);
        builder.Property(a => a.Details).HasMaxLength(500);

        builder.HasOne(a => a.User).WithMany().HasForeignKey(a => a.UserId).HasConstraintName("FK_audit_log_users").OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(a => new { a.Entity, a.EntityId }).HasDatabaseName("IX_audit_log_entity");
        builder.HasIndex(a => new { a.UserId, a.Timestamp }).HasDatabaseName("IX_audit_log_user_timestamp");
    }
}