using App.Domain.Clints;

namespace App.Application.Clints.Validator;

public class ClintErrorMessage : ValidatorErrorMessage
{
    //maybe we don't need CanNotUpdate
    #region CanNotUpdate 
    public static string CanNotUpdate = GetAsJson(new()
    {
        Ar = "لا يمكن تعديل",
        En = "Can not update"
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
        Ar = $"الاسم طويل جدا, يجب ان يحتوي الاسم على اقل من {ClintConstraintProperty.NameMaximumLength} حروف",
        En = $"Name is too long, The name must contain a maximum of {ClintConstraintProperty.NameMaximumLength} characters"
    });
    public static string NameMinimumLength = GetAsJson(new()
    {
        Ar = $"الاسم قصير جدا, يجب ان يحتوي الاسم على اكثر من {ClintConstraintProperty.NameMinimumLength} حروف",
        En = $"Name is too short , the name must contain at least {ClintConstraintProperty.NameMinimumLength} characters "
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
        Ar = $"الهاتف يجب ان يحتوي على {ClintConstraintProperty.PhoneLength} ارقام",
        En = $"Phone must be {ClintConstraintProperty.PhoneLength} characters"
    });
    #endregion

    #region SecandPhone
    public static string SecandPhoneFormat = GetAsJson(new()
    {
        Ar = "الهاتف يجب ان يحتوي على ارقام فقط",
        En = "Phone must contain numbers only"
    });
    public static string SecandPhoneLength = GetAsJson(new()
    {
        Ar = $"الهاتف يجب ان يحتوي على {ClintConstraintProperty.PhoneLength} ارقام",
        En = $"Phone must be {ClintConstraintProperty.PhoneLength} characters"
    });
    #endregion

    #region Weight
    public static string WeightMinimum = GetAsJson(new()
    {
        Ar = $"الوزن يجب ان يكون اكبر من {ClintConstraintProperty.WeightMinimum}",
        En = $"Weight must be greater than {ClintConstraintProperty.WeightMinimum}"
    });
    #endregion

    #region Hight
    public static string HightMinimum = GetAsJson(new()
    {
        Ar = $"الطول يجب ان يكون اكبر من {ClintConstraintProperty.HightMinimum}",
        En = $"Hight must be greater than {ClintConstraintProperty.HightMinimum}"
    });
    #endregion
}
