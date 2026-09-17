using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

namespace Pediatria.Infrastructure.Configurations.Users;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens", "dbo");
        builder.HasKey(rt => rt.Id).HasName("PK_refresh_tokens");
        builder.Property(rt => rt.Id).ValueGeneratedNever();

        builder.Property(rt => rt.TokenHash).HasMaxLength(256).IsRequired();
        builder.Property(rt => rt.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
        builder.Property(rt => rt.Revoked).HasDefaultValue(false);
        builder.Property(rt => rt.CreatedByIp).HasMaxLength(45);

        builder.HasOne(rt => rt.User).WithMany(u => u.RefreshTokens).HasForeignKey(rt => rt.UserId).HasConstraintName("FK_refresh_tokens_users").OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(rt => rt.UserId).HasFilter("[revoked] = 0").HasDatabaseName("IX_refresh_tokens_user");
    }
}