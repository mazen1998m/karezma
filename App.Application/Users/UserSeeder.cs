using App.core.Extensions;
using App.Domain.Enums;
using App.Domain.Users;
using App.Domain.Users.Roles;
using App.Domain.Users.Roles.Dtos;
using System.Data;

namespace App.Application.Users;

public class UserSeeder : IUserSeeder, IAutoInjection
{
    public IService<User> _userService { get; }
    public IService<Role> _roleService { get; }

    public UserSeeder(IService<User> userService, IService<Role> roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    public async Task<bool> SeedDataAsync()
    {
        try
        {

            if (await _roleService.AnyAsync())
            {
                await _roleService.CreateRangeAsync(GetRolse());
            }

            if (await _userService.AnyAsync()) return true;

            var developerRole = _roleService.FirstOrDefault(x => x.Name == SystemRole.Developer.ToString()).Response;

            var user = new User
            {
                Name = "Developer",
                Phone = "1234567890",
                UserType = UserType.Developer,
                Email = "mazen1998m@live.com",
                Password = "P@ssw0rd".ComputeSha256Hash(),
                Roles = new List<Role>() { developerRole },
                CreatedDate = DateTime.Now,
                CreatedBy = "System",
                IsActive = true

            };
            await _userService.CreateAsync(user);

            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }


    public IEnumerable<RoleDto> GetRolse()
        => Enum.GetValues(typeof(SystemRole))
           .Cast<SystemRole>()
           .Select(role => new RoleDto
           {
               Name = role.ToString(),
               //CreatedDate = DateTime.Now,
               //CreatedBy = "System",
               IsActive = true
           });

}




public interface IUserSeeder : IAutoInjection
{
    Task<bool> SeedDataAsync();
}
