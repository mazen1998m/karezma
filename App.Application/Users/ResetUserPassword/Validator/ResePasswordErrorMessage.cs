namespace App.Application.Users.ResetUserPassword.Validator;

public class ResePasswordErrorMessage : ValidatorErrorMessage
{
    public static string PasswordRequired = GetAsJson(new()
    {
        Ar = "كلمة المرور الجديدة مطلوبة",
        En = "New password is required"
    });

    public static string PasswordMinimumLength = GetAsJson(new()
    {
        Ar = $"كلمة المرور يجب ان تحتوي على اكثر من {ResePasswordConstraintProperty.PasswordMinimumLength} حرف",
        En = $"Password must contain at least {ResePasswordConstraintProperty.PasswordMinimumLength} characters"
    });
    public static string PasswordMaximumLength = GetAsJson(new()
    {
        Ar = $"كلمة المرور يجب ان تحتوي على اقل من {ResePasswordConstraintProperty.PasswordMaximumLength} حرف",
        En = $"Password must contain a maximum of {ResePasswordConstraintProperty.PasswordMaximumLength} characters"
    });
    public static string PasswordFormat = GetAsJson(new()
    {
        Ar = "كلمة المرور يجب ان تحتوي على حروف كبيرة وصغيرة وارقام",
        En = "Password must contain uppercase, lowercase and numbers"
    });
    public static string PasswordsDoNotMatch = GetAsJson(new()
    {
        Ar = "كلمة المرور غير متطابقة",
        En = "Passwords do not match"
    });

}
