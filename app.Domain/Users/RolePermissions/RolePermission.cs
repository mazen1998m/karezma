using App.Domain.Users.Permissions;
using App.Domain.Users.Roles;

namespace App.Domain.Users.RolePermissions;

public class RolePermission : Entity
{
    public Role Role { get; set; }
    public int RoleId { get; set; }
    public Permission Permission { get; set; }
    public int PermissionId { get; set; }

    internal class Configuration : ConfigureTable<RolePermission>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });
            Builder.HasOne(rp => rp.Role)
                   .WithMany()
                   .HasForeignKey(rp => rp.RoleId);
            Builder.HasOne(rp => rp.Permission)
                   .WithMany()
                   .HasForeignKey(rp => rp.PermissionId);
        }
    }
}
