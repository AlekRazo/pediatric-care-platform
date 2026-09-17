using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

namespace Pediatria.Infrastructure.Configurations.Users;

public class PhysicianConfiguration : IEntityTypeConfiguration<Physician>
{
    public void Configure(EntityTypeBuilder<Physician> builder)
    {
        builder.ToTable("physicians", "dbo", t=> t.HasCheckConstraint("CK_physicians_gender", "[gender] IN (N'Masculino', N'Femenino, N'Otro')"));
        builder.HasKey(p => p.UserId).HasName("PK_physicians");

        builder.Property(p => p.FullName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Gender).HasMaxLength(10).IsRequired();
        
        builder.Property(p => p.ProfessionalLicenseNumber).HasMaxLength(20).IsRequired();
        builder.HasIndex(p => p.ProfessionalLicenseNumber).IsUnique().HasDatabaseName("UQ_physicians_professional_license_number");

        builder.Property(p => p.EducationalInstitution).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Specialty).HasMaxLength(100).IsRequired();

        builder.HasOne(p => p.User).WithOne(u => u.Physician).HasForeignKey<Physician>(p => p.UserId).HasConstraintName("FK_physicians_users").OnDelete(DeleteBehavior.Cascade);
    }
}