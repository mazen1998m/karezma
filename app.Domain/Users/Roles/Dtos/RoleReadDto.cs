
using App.Domain.Users.RolePermissions.Dtos;
using App.Domain.Users.UserRoles.Dtos;

namespace App.Domain.Users.Roles.Dtos;

public class RoleReadDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<UserRolesDto> UserRoles { get; set; } = new();
    public virtual List<RolePermissionReadDto> RolePermissions { get; set; } = new();
    public bool IsActive { get; set; }
}
