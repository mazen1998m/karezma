namespace App.Domain.Users.Auths;

public class LoginResponse : IdNameDto
{
    public string Token { get; set; }
}
