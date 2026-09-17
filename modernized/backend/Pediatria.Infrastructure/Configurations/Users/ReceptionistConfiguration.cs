using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

namespace Pediatria.Infrastructure.Configurations.Users;

public class ReceptionistConfiguration : IEntityTypeConfiguration<Receptionist>
{
    public void Configure(EntityTypeBuilder<Receptionist> builder)
    {
        builder.ToTable("receptionists", "dbo", t=> t.HasCheckConstraint("CK_receptionists_gender", "[gender] IN (N'Masculino', N'Femenino', N'Otro')"));
        builder.HasKey(r => r.UserId).HasName("PK_receptionists");

        builder.Property(r => r.FullName).HasMaxLength(100).IsRequired();
        builder.Property(r => r.Gender).HasMaxLength(10).IsRequired();

        builder.HasOne(r => r.User).WithOne(u => u.Receptionist).HasForeignKey<Receptionist>(r => r.UserId).HasConstraintName("FK_receptionists_users").OnDelete(DeleteBehavior.Cascade);
    }
}