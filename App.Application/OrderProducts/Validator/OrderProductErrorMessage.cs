using App.Domain.OrderProducts;

namespace App.Application.OrderProducts.Validator;

public class OrderProductErrorMessage : ValidatorErrorMessage
{

    #region Quantity

    public static string QuantityMinimumValue = GetAsJson(new()
    {
        Ar = $"الكمية يجب ان تكون اكبر من او تساوي {OrderProductConstraintProperty.QuantityMinimumValue}",
        En = $"Quantity must be greater than or equal {OrderProductConstraintProperty.QuantityMinimumValue}"
    });

    #endregion

    #region Price

    public static string PriceMinimumValue = GetAsJson(new()
    {
        Ar = $"السعر يجب ان يكون اكبر من او تساوي {OrderProductConstraintProperty.PriceMinimumValue}",
        En = $"Price must be greater than or equal {OrderProductConstraintProperty.PriceMinimumValue}"
    });

    public static string PriceMaximumValue = GetAsJson(new()
    {
        Ar = $"السعر يجب ان يكون اقل من او يساوي {OrderProductConstraintProperty.PriceMaximumValue}",
        En = $"Price must be less than or equal {OrderProductConstraintProperty.PriceMaximumValue}"
    });

    #endregion

    #region Notes

    public static string NotesMaximumLength = GetAsJson(new()
    {
        Ar = $"الملاحظات طويلة جدا, يجب ان تحتوي الملاحظات على اقل من {OrderProductConstraintProperty.NotesMaximumLength} حروف",
        En = $"Notes is too long, The notes must contain a maximum of {OrderProductConstraintProperty.NotesMaximumLength} characters"
    });

    #endregion

    #region ProductId
    public static string ProductIdRequired = GetAsJson(new()
    {
        Ar = "معرف المنتج مطلوب",
        En = "Product id is required"
    });

    public static string ProductIdNotExsist = GetAsJson(new()
    {
        Ar = "المنتج غير موجود",
        En = "Product not exsist"
    });
    #endregion
}
