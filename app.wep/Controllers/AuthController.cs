using App.Application.Users;
using App.Domain.Users.Auths;

namespace App.web.Controllers;
[ApiController]
[Route("[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        return Ok(await _authService.Login(request));


    }

    [HttpGet]
    public IActionResult Logout()
    {
        _authService.Logout();
        return Ok();
    }

}
