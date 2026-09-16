using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles", t => t.HasCheckConstraint("CK_roles_name", "[name] IN (N'Administrator', N'Physician', N'Receptionist')"));
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name).IsRequired().HasMaxLength(30);
        builder.HasIndex(r => r.Name).IsUnique();
    }
}