using App.Domain.Users.Roles.Dtos;

namespace App.Domain.Users.UserRoles.Dtos;

public class UserRolesDto : Dto
{
    public int UserId { get; set; }
    public List<RoleDto> Roles { get; set; }

}
