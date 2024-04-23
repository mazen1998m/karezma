using App.core.Extensions;
using App.core.Helpers;
using App.core.InjectionHelper;
using App.Domain.Enums;


namespace App.Domain.Users;

using Lambda = Expression<System.Func<App.Domain.Users.User, bool>>;

public class UserFilterV2 : Filter<User>
{
    private readonly UserType _userType;
    private ICurrentUser _currentUser { get; }
    public UserFilterV2()
    {
        _currentUser = _currentUser.Inject();
        _userType = _currentUser.UserType.ToEnum<UserType>();
    }

    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public UserType? userType { get; set; }

    public Lambda _Email() => x => x.Email.Contains(Email!);
    public Lambda _Name() => x => x.Name.Contains(Name!);
    public Lambda _Phone() => x => x.Phone.Contains(Phone!);
    public Lambda _UserType() => x => x.UserType == userType.Value;


    //public Lambda _FilterByWarehouseId() => s => s.WarehouseId == _currentUser.WarehouseId;
    protected override void ApplyFilter()
    {

        //AddFilter(
        //(_userType == UserType.Employee
        //|| _userType == UserType.Customer
        //|| _userType == UserType.Admin), _FilterByWarehouseId());

        AddFilter(Email is not null, _Email());
        AddFilter(Name is not null, _Name());
        AddFilter(Phone is not null, _Phone());
        AddFilter(userType is not null, _UserType());
    }

}

