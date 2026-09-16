namespace Pediatria.Domain.Entities.Users;

public sealed class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}