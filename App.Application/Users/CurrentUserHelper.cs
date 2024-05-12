using App.Domain.Users;
using App.Domain.Users.Permissions.Dtos;
using Microsoft.AspNetCore.Http;
using UAParser;

namespace App.Application.Users;

public class CurrentUserHelper : IAutoInjection, ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IService<User> _service { get; set; }

    public CurrentUserHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;

    }

    public int UserId
    {
        get
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == nameof(User.Id))!.Value;
                return int.TryParse(userId, out int parsedUserId) ? parsedUserId : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

    public string UserType
    {
        get
        {
            try
            {
                _service = _service.Inject();
                var userType = _service.Find(x => x.Id == UserId, x => new { x.Id, x.UserType }).Response.FirstOrDefault().UserType.ToString();
                return userType;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
    public IEnumerable<string> Permissions
    {
        get
        {
            try
            {
                _service = _service.Inject();
                var permisions = _service.SingleOrDefault<UserPermissionsDto>(x => x.UserId == UserId).Response.Permission;

                return permisions;
            }
            catch (Exception)
            {
                return default;
            }

        }
    }

    public string UserName
    {
        get
        {
            try
            {
                _service = _service.Inject();
                var userType = _service.Find(x => x.Id == UserId, x => new { x.Id, x.Name }).Response.FirstOrDefault().Name.ToString();
                return userType;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
    public string Email
    {
        get
        {
            try
            {
                _service = _service.Inject();
                var userType = _service.Find(x => x.Id == UserId, x => new { x.Id, x.Email }).Response.FirstOrDefault().Email.ToString();
                return userType;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
    public string Phone
    {
        get
        {
            try
            {
                _service = _service.Inject();
                var userType = _service.Find(x => x.Id == UserId, x => new { x.Id, x.Phone }).Response.FirstOrDefault().Phone.ToString();
                return userType;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
    public string RemoteIpAddress
    {
        get { return _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty; }
    }

    public string Browser
    {
        get
        {
            var userAgent = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(userAgent);
            var browserName = clientInfo.UA.Family;
            return browserName;
        }
    }

    public bool IsUserHasPermission(string permission)
    {
        _service = _service.Inject();
        return Permissions.Contains(permission);
    }


}
