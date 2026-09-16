using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

namespace Pediatria.Infrastructure.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.HasIndex(u => u.Username).IsUnique();

        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.PasswordHash).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Active).HasDefaultValue(true);
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

        builder.HasIndex(u=> u.Id).HasFilter("[Active] = 1").HasDatabaseName("IX_active_users");
    }
}