namespace App.Domain.Users.Permissions.Dtos;

public class UserPermissionsDto : Dto
{
    public int UserId { get; set; }
    public IEnumerable<string> Permission { get; set; }
}
