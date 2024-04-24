using App.Application.Const;

namespace App.Application.Products.Validator;

public class ProductErrorMessage : ValidatorErrorMessage
{

    #region Name
    public static string NameRequired = GetAsJson(new()
    {
        Ar = "الاسم مطلوب",
        En = "Name is required"
    });
    public static string NameMaximumLength = GetAsJson(new()
    {
        Ar = $"الاسم طويل جدا, يجب ان يحتوي الاسم على اقل من {ProductConstraintProperty.NameMaximumLength} حروف",
        En = $"Name is too long, The name must contain a maximum of {ProductConstraintProperty.NameMaximumLength} characters"
    });
    public static string NameMinimumLength = GetAsJson(new()
    {
        Ar = $"الاسم قصير جدا, يجب ان يحتوي الاسم على اكثر من {ProductConstraintProperty.NameMinimumLength} حروف",
        En = $"Name is too short , the name must contain at least {ProductConstraintProperty.NameMinimumLength} characters "
    });

    public static string NameUnique = GetAsJson(new()
    {
        Ar = "الاسم موجود مسبقا",
        En = "Name is already exists"
    });


    #endregion

    #region Model
    public static string ModelRequired = GetAsJson(new()
    {
        Ar = "الموديل مطلوب",
        En = "Model is required"
    });

    public static string ModelMaximumLength = GetAsJson(new()
    {
        Ar = $"الموديل طويل جدا, يجب ان يحتوي الموديل على اقل من {ProductConstraintProperty.ModelMaximumLength} حروف",
        En = $"Model is too long, The model must contain a maximum of {ProductConstraintProperty.ModelMaximumLength} characters"
    });

    public static string ModelMinimumLength = GetAsJson(new()
    {
        Ar = $"الموديل قصير جدا, يجب ان يحتوي الموديل على اكثر من {ProductConstraintProperty.ModelMinimumLength} حروف",
        En = $"Model is too short , the model must contain at least {ProductConstraintProperty.ModelMinimumLength} characters "
    });

    public static string ModelUnique = GetAsJson(new()
    {
        Ar = "الموديل موجود مسبقا",
        En = "Model is already exists"
    });

    #endregion

    #region Barcode

    public static string BarcodeMaximumLength = GetAsJson(new()
    {
        Ar = $"الباركود طويل جدا, يجب ان يحتوي الباركود على اقل من {ProductConstraintProperty.BarcodeMaximumLength} حروف",
        En = $"Barcod is too long, The barcod must contain a maximum of {ProductConstraintProperty.BarcodeMaximumLength} characters"
    });

    public static string BarcodeMinimumLength = GetAsJson(new()
    {
        Ar = $"الباركود قصير جدا, يجب ان يحتوي الباركود على اكثر من {ProductConstraintProperty.BarcodeMinimumLength} حروف",
        En = $"Barcod is too short , the barcod must contain at least {ProductConstraintProperty.BarcodeMinimumLength} characters "
    });

    public static string BarcodeFormat = GetAsJson(new()
    {
        Ar = "الباركود يجب ان يحتوي على ارقام فقط",
        En = "Barcod must contain numbers only"
    });

    public static string BarcodeUnique = GetAsJson(new()
    {
        Ar = "الباركود موجود مسبقا",
        En = "Barcod is already exists"
    });

    #endregion

    #region Description

    public static string DescriptionMaximumLength = GetAsJson(new()
    {
        Ar = $"الوصف طويل جدا, يجب ان يحتوي الوصف على اقل من {ProductConstraintProperty.DescriptionMaximumLength} حروف",
        En = $"Description is too long, The description must contain a maximum of {ProductConstraintProperty.DescriptionMaximumLength} characters"
    });

    #endregion

}
