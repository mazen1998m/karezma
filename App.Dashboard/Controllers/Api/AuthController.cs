using App.Application.Users;
using App.Domain.Users.Auths;

namespace App.Dashboard.Controllers.Api;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;


    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> MobileLogin(LoginRequest request)
    {
        return Ok(await _authService.MobileLogin(request));


    }



}
