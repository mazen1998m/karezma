using App.Application.Const;

namespace App.Application.Representatives.Validator;

public class RepresentativeErrorMessage : ValidatorErrorMessage
{

    #region UserName
    public static string UserNameRequired = GetAsJson(new()
    {
        Ar = "اسم المستخدم مطلوب",
        En = "Username is required"
    });

    public static string UsernameIsUesd = GetAsJson(new()
    {
        Ar = "اسم المستخدم مستخدم مسبقا",
        En = "Username is already used"
    });

    public static string UsernameMaximumLength = GetAsJson(new()
    {
        Ar = $"اسم المستخدم طويل جدا, يجب ان يحتوي اسم المستخدم على اقل من {RepresentativeConstraintProperty.UserNameMaximumLength} حروف",
        En = $"Username is too long, The username must contain a maximum of {RepresentativeConstraintProperty.UserNameMaximumLength} characters"
    });

    public static string UsernameMinimumLength = GetAsJson(new()
    {
        Ar = $"اسم المستخدم قصير جدا, يجب ان يحتوي اسم المستخدم على اكثر من {RepresentativeConstraintProperty.UserNameMinimumLength} حروف",
        En = $"Username is too short , the username must contain at least {RepresentativeConstraintProperty.UserNameMinimumLength} characters "
    });

    #endregion

    #region Name
    public static string NameRequired = GetAsJson(new()
    {
        Ar = "الاسم مطلوب",
        En = "Name is required"
    });
    public static string NameMaximumLength = GetAsJson(new()
    {
        Ar = $"الاسم طويل جدا, يجب ان يحتوي الاسم على اقل من {RepresentativeConstraintProperty.NameMaximumLength} حروف",
        En = $"Name is too long, The name must contain a maximum of {RepresentativeConstraintProperty.NameMaximumLength} characters"
    });
    public static string NameMinimumLength = GetAsJson(new()
    {
        Ar = $"الاسم قصير جدا, يجب ان يحتوي الاسم على اكثر من {RepresentativeConstraintProperty.NameMinimumLength} حروف",
        En = $"Name is too short , the name must contain at least {RepresentativeConstraintProperty.NameMinimumLength} characters "
    });
    #endregion

    #region Phone
    public static string PhoneRequired = GetAsJson(new()
    {
        Ar = "الهاتف مطلوب",
        En = "Phone is required"
    });


    public static string PhoneFormat = GetAsJson(new()
    {
        Ar = "الهاتف يجب ان يحتوي على ارقام فقط",
        En = "Phone must contain numbers only"
    });
    public static string PhoneLength = GetAsJson(new()
    {
        Ar = $"الهاتف يجب ان يحتوي على {RepresentativeConstraintProperty.PhoneLength} ارقام",
        En = $"Phone must be {RepresentativeConstraintProperty.PhoneLength} characters"
    });

    #endregion

    #region Commision
    public static string CommisionMinimum = GetAsJson(new()
    {
        Ar = $"العمولة يجب ان تكون اكبر من {RepresentativeConstraintProperty.CommisionMinimum}",
        En = $"Commision must be greater than {RepresentativeConstraintProperty.CommisionMinimum}"
    });
    #endregion



}
