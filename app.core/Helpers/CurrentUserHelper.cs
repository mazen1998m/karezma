using App.core.InjectionHelper;

namespace App.core.Helpers;

public interface ICurrentUser : IAutoInjection
{
    int UserId { get; }
    string RemoteIpAddress { get; }
    string Browser { get; }
    public IEnumerable<string> Permissions { get; }

    bool IsUserHasPermission(string permission);
    string UserName { get; }
    string Email { get; }
    string Phone { get; }
    string UserType { get; }
    bool IsAdmin { get; }
    string DeviceToken { get; }

}