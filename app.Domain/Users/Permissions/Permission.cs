using App.Domain.Users.Roles;

namespace App.Domain.Users.Permissions;

public class Permission : Entity
{
    public string Name { get; set; }
    public string EndPointName { get; set; }
    public virtual ICollection<Role> Roles { get; set; }

    internal class Configuration : ConfigureTable<Permission>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.HasIndex(c => new { c.Name, c.IsDeleted, c.EndPointName }).IsUnique();
        }
    }

}
