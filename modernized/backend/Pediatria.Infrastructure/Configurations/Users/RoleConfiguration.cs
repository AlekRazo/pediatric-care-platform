using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pediatria.Domain.Entities.Users;

namespace Pediatria.Infrastructure.Configurations.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles", "dbo", t => t.HasCheckConstraint("CK_roles_name", "[name] IN (N'Administrator', N'Physician', N'Receptionist')"));
        builder.HasKey(r => r.Id).HasName("PK_roles");
        
        builder.Property(r => r.Name).HasMaxLength(30).IsRequired();
        builder.HasIndex(r => r.Name).IsUnique().HasDatabaseName("UQ_roles_name");
    }
}