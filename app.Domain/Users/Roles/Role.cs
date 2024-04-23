using App.Domain.Users.Permissions;
using App.Domain.Users.RolePermissions;

namespace App.Domain.Users.Roles;

public class Role : Entity
{
    public string Name { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
    public bool IsActive { get; set; }

    internal class Configuration : ConfigureTable<Role>
    {
        protected override void ConfigureCustomizations()
        {

            Builder.HasMany(r => r.Permissions)
               .WithMany(p => p.Roles)
               .UsingEntity<RolePermission>(
                    rp => rp.HasOne(rp => rp.Permission)
                            .WithMany(),
                    rp => rp.HasOne(rp => rp.Role)
                            .WithMany(),
                    rp =>
                    {
                        rp.HasKey(rp => new { rp.RoleId, rp.PermissionId });
                        rp.ToTable(nameof(RolePermission));
                    });
            Builder.HasIndex(c => new { c.Name, c.IsDeleted }).IsUnique();
        }
    }
}
