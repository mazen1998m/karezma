using App.Domain.Addresses;
using App.Domain.Documents;
using App.Domain.Enums;
using App.Domain.Users.Roles;
using App.Domain.Users.UserRoles;

namespace App.Domain.Users;

public class User : Entity
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? PhotoUrl { get; set; }
    public UserType UserType { get; set; }
    public Address? Address { get; set; }
    public List<Document> Documents { get; set; }
    public ICollection<Role> Roles { get; set; }
    public bool IsActive { get; set; }


    internal class Configuration : ConfigureTable<User>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.HasMany(u => u.Roles)
               .WithMany(r => r.Users)
               .UsingEntity<UserRole>(
                    ur => ur.HasOne(ur => ur.Role)
                            .WithMany(),
                    ur => ur.HasOne(ur => ur.User)
                            .WithMany(),
                    ur =>
                    {
                        ur.HasKey(ur => new { ur.UserId, ur.RoleId });
                        ur.ToTable(nameof(UserRole));
                    });

            Builder.Property(u => u.IsActive).HasDefaultValue(true);

            Builder.HasMany(c => c.Documents).WithOne(d => d.User).OnDelete(DeleteBehavior.Cascade);
            Builder.HasIndex(c => new { c.Email, c.IsDeleted }).IsUnique();
            Builder.Property(u => u.Name).IsRequired();
            Builder.Property(u => u.Password).IsRequired();

        }
    }
}
