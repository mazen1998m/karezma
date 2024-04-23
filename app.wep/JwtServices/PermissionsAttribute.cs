using App.core.Helpers;
using App.core.InjectionHelper;
using App.Domain.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Muslim.HandelResult;

namespace App.web.JwtServices;
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class PermissionsAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private ICurrentUser _currentUser { get; set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {

        //get the user permission from the token
        var userPermissions = context.HttpContext.User.Claims.Where(x => x.Type == "Permission").Select(x => x.Value).ToList();

        //Get the name of the method that is currently using this attribute
        //along with the Controller name
        var controller = context.RouteData.Values["controller"]?.ToString();
        var action = context.RouteData.Values["action"]?.ToString();
        var permissionName = $"{controller}.{action}";

        //Check if the user has the permission to access the method
        if (IsUserHasPermissopn(context)) return;

        //If the user doesn't have the permission return 401 status code with a message 


        context.Result = new JsonResult(Result<UserDetailsDto>.Fail("You don't have permission to access"))
        { StatusCode = 401 };



    }

    public bool IsUserHasPermissopn(AuthorizationFilterContext context)
    {
        var controller = context.RouteData.Values["controller"]?.ToString();
        var action = context.RouteData.Values["action"]?.ToString();
        var permissionName = $"{controller}.{action}";

        var currentUser = _currentUser.Inject();

        return currentUser.IsUserHasPermission(permissionName);

    }

}
