namespace App.Application.Users.ResetUserPassword.Validator;

public class ResePasswordConstraintProperty
{
    public static int PasswordMinimumLength = 6;
    public static int PasswordMaximumLength = 50;
    public static string PasswordMatches = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,50}$";

}
