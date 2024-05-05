using App.Application.Users;
using App.Domain.Users.Auths;

namespace App.Dashboard.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (HttpContext.Session.Get("token") is null)
            return View(new LoginRequest());
        return RedirectToAction("Index", "Home");
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            request.IsAdmin = true;
            var token = (await _authService.Login(request)).Response!.Token;
            HttpContext.Session.SetString("token", token);
            return RedirectToAction("Index", "Home");

        }
        catch (Exception)
        {
            ViewBag.ErrorMessage = "Username or password is incorrect.";
            return View("Login");
        }
    }






    [HttpPost]
    public IActionResult Logout()
    {
        _authService.Logout();
        HttpContext.Session.Remove("token");
        return RedirectToAction("Login", "Auth");
    }


}
