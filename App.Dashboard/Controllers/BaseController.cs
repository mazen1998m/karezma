using App.core.Helpers;
using App.core.InjectionHelper;
using App.Domain.Users;
using MaxMind.GeoIP2.Exceptions;

namespace App.Dashboard.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class BaseController : Controller
{
    public ICurrentUser _currentUser { get; set; }

    protected User CurruntUser()
    {
        try
        {
            var currentUser = _currentUser.Inject();
            return new User
            {

                Name = currentUser.UserName,

            };
        }
        catch (Exception ex)
        {
            return new User
            {
                Name = "Guest"
            };
        }


    }
    protected RedirectToActionResult HandelException(Exception ex)
    {


        int httpStatusCode = ex is HttpException httpException
            ? (int)httpException.HttpStatus
            : Response.StatusCode;
        return httpStatusCode switch
        {
            400 => RedirectToAction("BadRequest", "Error"),
            _ => RedirectToAction("InternalServerError", "Error")
        };

    }

    protected RedirectToActionResult GoTo(string actionName, string controllerName = "")
        => controllerName == ""
            ? RedirectToAction(actionName)
            : RedirectToAction(actionName, controllerName);




}