namespace App.Domain.Users.Permissions.Dtos;

public class PermissionReadDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string EndPointName { get; set; }
}
