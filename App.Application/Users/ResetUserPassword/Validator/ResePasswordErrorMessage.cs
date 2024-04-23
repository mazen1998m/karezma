namespace App.Application.Users.ResetUserPassword.Validator;

public static class ResePasswordErrorMessage
{
    #region ResetPassword
    public static string PasswordRequired = "New password is required";
    public static string PasswordMinimumLength = "Password must be at least 6 characters";
    public static string PasswordMaximumLength = "Password must be at most 50 characters";
    public static string PasswordFormat = "Password must contain at least one uppercase letter, one lowercase letter and one number";
    public static string PasswordsDoNotMatch = "Passwords do not match";
    #endregion

}
