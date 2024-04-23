namespace App.Domain.Users.Permissions;

using Muslim.Filter;
using Lampda = Expression<Func<Permission, bool>>;
public class PermissionFilter : Filter<Permission>
{
    public string Name { get; set; }
    public string IsDeleted { get; set; }

    public Lampda _Name() => x => x.Name.Contains(Name!);
    public Lampda _IsDeleted() => x => x.IsDeleted == false;
    protected override void ApplyFilter()
    {
        AddFilter(Name is not null, _Name());
        AddFilter(IsDeleted is not null, _IsDeleted());
    }
}
