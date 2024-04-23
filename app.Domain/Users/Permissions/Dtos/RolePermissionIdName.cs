namespace App.Domain.Users.Permissions.Dtos;

public class RolePermissionIdName
{
    public IdNameDto Role { get; set; }
    public List<IdNameDto> Permissions { get; set; }
}
