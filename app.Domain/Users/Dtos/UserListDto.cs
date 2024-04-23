using App.Domain.Enums;

namespace App.Domain.Users.Dtos;

public class UserListDto : IdNameDto
{
    public string Phone { get; set; }
    public string Email { get; set; }
    public UserType UserType { get; set; }
}
