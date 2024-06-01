using App.core.Helpers;
using App.core.InjectionHelper;
using App.core.Muslim.Result;
using App.Dashboard.Controllers;
using App.Domain.Users.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;


namespace App.Dashboard.JwtServices;
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class PermissionsAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _controllerName;
    private readonly string _methodName;
    private readonly string _defultContollerRedirect = nameof(ErrorController);
    private readonly string _defultMethodRedirect = nameof(ErrorController.Unutilized);

    private ICurrentUser _currentUser { get; set; }

    public PermissionsAttribute(string controllerName = "", string methodName = "")
    {
        _controllerName = controllerName!.Replace("Controller", "");
        _methodName = methodName;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        //get token from the mvc session 
        var token = context.HttpContext.Session.GetString("token");

        if (string.IsNullOrEmpty(token))
        {
            //If the token is null return 401 status code without a message 
            context.Result = new JsonResult(Result<UserDetailsDto>.Fail("You are not authorized"))
            { StatusCode = 401 };
            return;
        }


        if (IsUserHasPermissopn(context)) return;

        // redirect to login page

        if (string.IsNullOrEmpty(_controllerName) && string.IsNullOrEmpty(_methodName))
        {
            context.Result = new RedirectToActionResult(_defultContollerRedirect, _defultMethodRedirect, null);
            return;
        }

        context.Result = new RedirectToActionResult(_methodName, _controllerName, null);




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
