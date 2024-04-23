using App.Application.Users;
using App.Domain.Users;
using App.Domain.Users.Dtos;

namespace App.web.Controllers;

public class UserController : ApiController<User, CreateUserDto, UserDetailsDto>
{
    #region ctor
    public IUserSeeder _seeder { get; }
    public UserController(IService<User> service, IUserSeeder seeder) : base(service)
    {
        _seeder = seeder;
    }

    #endregion

    [HttpGet]
    public async Task<IActionResult> Seed()
    {
        await _seeder.SeedDataAsync();
        return Ok();
    }
}
