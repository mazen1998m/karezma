namespace App.Domain.Users;

using App.Domain.Enums;
using Lampda = Expression<Func<User, bool>>;
public class UserFilter : Filter<User>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }

    public UserType? UserType { get; set; }


    public Lampda _Name() => x => x.Name.Contains(Name!);
    public Lampda _Phone() => x => x.Phone.Contains(Phone!);
    public Lampda _CurruntUserType() => x =>  x.UserType != Enums.UserType.Developer;

    

    protected override void ApplyFilter()
    {
        AddFilter(Name is not null, _Name());
        AddFilter(Phone is not null, _Phone());


        AddFilter(UserType is not null && UserType != Enums.UserType.Developer , _CurruntUserType());
    }
}
