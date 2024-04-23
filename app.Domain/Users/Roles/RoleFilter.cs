namespace App.Domain.Users.Roles;

using App.Domain.Enums;
using Lampda = Expression<Func<Role, bool>>;
public class RoleFilter : Filter<Role>
{

    public string Name { get; set; }

    public UserType? UserType { get; set; }

    public Lampda _Name() => x => x.Name.Contains(Name!);

    public Lampda _UserType() => x =>
    //x.Name != RolesName.Developer.ToString() &&
    x.Name != SystemRole.SuperAdmin.ToString() &&
    x.Name != SystemRole.Customer.ToString() &&
    x.Name != SystemRole.Employee.ToString() &&
    x.Name != SystemRole.SuperAdmin.ToString();


    protected override void ApplyFilter()
    {
        AddFilter(Name is not null, _Name());
        AddFilter(UserType is not null && UserType != Enums.UserType.Developer, _UserType());
    }
}

