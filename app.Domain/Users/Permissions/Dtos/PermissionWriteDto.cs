namespace App.Domain.Users.Permissions.Dtos;

public class PermissionWriteDto : Dto
{
    public string Name { get; set; }
    public string EndPointName { get; set; }
    public List<int> Roles { get; set; }
}
