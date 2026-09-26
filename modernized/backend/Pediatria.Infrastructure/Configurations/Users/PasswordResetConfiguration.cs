using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

namespace Pediatria.Infrastructure.Configurations.Users;

public class PasswordResetConfiguration : IEntityTypeConfiguration<PasswordReset>
{
    public void Configure(EntityTypeBuilder<PasswordReset> builder)
    {
        builder.ToTable("password_resets", "dbo");
        builder.HasKey(pr => pr.Id).HasName("PK_password_resets");
        builder.Property(pr => pr.Id).ValueGeneratedNever();

        builder.Property(pr => pr.TokenHash).HasMaxLength(256).IsRequired();
        builder.Property(pr => pr.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

        builder.HasOne(pr => pr.User).WithMany().HasForeignKey(pr => pr.UserId).HasConstraintName("FK_password_resets_users").OnDelete(DeleteBehavior.Cascade);
    }
}