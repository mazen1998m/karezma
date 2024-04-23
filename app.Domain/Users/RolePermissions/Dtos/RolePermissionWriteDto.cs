using App.Domain.Users.Roles;

namespace App.Domain.Users.RolePermissions.Dtos;

public class RolePermissionWriteDto : Dto
{
    public Role Role { get; set; }

    public List<int> PermissionIds { get; set; }
    public bool IsActive { get; set; }
}
