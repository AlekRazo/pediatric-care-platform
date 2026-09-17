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

        builder.Property(pr => pr.TempPasswordHash).HasMaxLength(256).IsRequired();
        builder.Property(pr => pr.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
        builder.Property(pr => pr.Used).HasDefaultValue(false);

        builder.HasOne(pr => pr.User).WithMany().HasForeignKey(pr => pr.UserId).HasConstraintName("FK_password_resets_users").OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(pr => pr.Admin).WithMany().HasForeignKey(pr => pr.AdminId).HasConstraintName("FK_password_resets_admin").OnDelete(DeleteBehavior.NoAction);
    }
}