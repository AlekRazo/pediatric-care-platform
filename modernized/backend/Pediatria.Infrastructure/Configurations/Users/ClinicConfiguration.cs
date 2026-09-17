using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.ToTable("clinics", "dbo", t=> t.HasCheckConstraint("CK_clinic_id", "[id] = 1"));
        builder.HasKey(c => c.Id).HasName("PK_clinic");
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Address).HasMaxLength(150).IsRequired();
        builder.Property(c => c.Phone).HasMaxLength(15).IsRequired();
    }
}