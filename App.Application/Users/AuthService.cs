using App.core.Muslim.Result;
using App.Domain.Users;
using App.Domain.Users.Auths;

namespace App.Application.Users;

internal class AuthService : IAuthService, IAutoInjection
{
    private readonly IService<User> _usersService;
    private readonly IRepository<User> _usersRepository;

    private readonly JwtService _jwtService;

    public AuthService(IService<User> usersService, JwtService jwtService, IRepository<User> usersRepository)
    {
        _usersService = usersService;
        _jwtService = jwtService;
        _usersRepository = usersRepository;
    }



    public async Task<Result<LoginResponse>> Login(LoginRequest request)
    {
        var authResponse = await _usersService.SingleOrDefaultAsync<LoginResponse>(x => x.IsActive == true && x.Email == request.Email
                   && x.Password == request.Password.ComputeSha256Hash() && x.IsAdmin == request.IsAdmin);
        if (!authResponse.IsSuccess) return authResponse;

        _jwtService.SetToken(authResponse.Response);

        return authResponse;

    }

    public async Task<Result<LoginResponse>> MobileLogin(LoginRequest request)
    {

        var authResponse = await Login(request);
        if (authResponse.IsSuccess && authResponse.Response != null && request.DeviceToken.IsNotNullOrEmpty())
        {

            var deviceToken = (await _usersRepository.FirstOrDefaultAsync(x => x.Id == authResponse.Response.Id, s => new
            {
                s.Id,
                s.DeviceToken
            })).DeviceToken;

            if (deviceToken != request.DeviceToken)
            {
                var user = (await _usersRepository.SingleOrDefaultAsync(x => x.Id == authResponse.Response.Id));
                user.DeviceToken = request.DeviceToken;
                await _usersRepository.SaveUpdateAsync(user);
            }


        }
        return authResponse;

    }


    public void Logout() => _jwtService.RemoveToken();


}

public interface IAuthService : IAutoInjection
{
    Task<Result<LoginResponse>> Login(LoginRequest request);
    Task<Result<LoginResponse>> MobileLogin(LoginRequest request);
    void Logout();
}


