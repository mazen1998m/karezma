namespace App.Domain.Users.Roles.Dtos;

public class RoleWriteDto : Dto
{
    public string Name { get; set; }
    public List<int> PermissionIds { get; set; }
    public bool IsActive { get; set; }
}
