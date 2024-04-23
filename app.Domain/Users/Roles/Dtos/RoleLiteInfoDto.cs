namespace App.Domain.Users.Roles.Dtos;

public class RoleLiteInfoDto
{
    public string RoleName { get; set; }
    public int RoleId { get; set; }
    public List<int> Users { get; set; }
    public List<int> Permissions { get; set; }
}
