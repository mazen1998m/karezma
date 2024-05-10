using App.Application.Users;
using App.Domain.Users.Auths;

namespace App.Dashboard.Controllers.Api;

public class AuthController : ShareController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        return Ok(await _authService.MobileLogin(request));


    }

    [HttpGet]
    public IActionResult Logout()
    {
        _authService.Logout();
        return Ok();
    }

}
