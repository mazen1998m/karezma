namespace App.Domain.Users.Auths;

public class ResetPassword : Dto
{
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }


}
