using App.Domain.Users;
using App.Domain.Users.Auths;

namespace App.Application.Users;

internal class AuthService : IAuthService, IAutoInjection
{
    private readonly IService<User> _usersService;
    private readonly JwtService _jwtService;

    public AuthService(IService<User> usersService, JwtService jwtService)
    {
        _usersService = usersService;
        _jwtService = jwtService;
    }



    public async Task<Result<LoginResponse>> Login(LoginRequest request)
    {
        var authResponse = await _usersService.SingleOrDefaultAsync<LoginResponse>(x => x.IsActive == true && x.Email == request.Email
                   && x.Password == request.Password.ComputeSha256Hash() && x.IsAdmin == request.IsAdmin);
        if (!authResponse.IsSuccess) return authResponse;

        _jwtService.SetToken(authResponse.Response);

        return authResponse;

    }


    public void Logout() => _jwtService.RemoveToken();


}

public interface IAuthService : IAutoInjection
{
    public Task<Result<LoginResponse>> Login(LoginRequest request);
    public void Logout();
}


