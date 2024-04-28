using App.Domain.Orders;

namespace App.Application.Orders.Validator;

public class OrderErrorMessage : ValidatorErrorMessage
{
    #region CanNotUpdate

    public static string CanNotUpdate = GetAsJson(new()
    {
        Ar = "لا يمكن تعديل الطلب",
        En = "Can not update order"
    });

    #endregion

    #region Barcode

    public static string BarcodeMaximumLength = GetAsJson(new()
    {
        Ar = $"الباركود طويل جدا, يجب ان يحتوي الباركود على اقل من {OrderConstraintProperty.BarcodeMaximumLength} حروف",
        En = $"Name is too long, The name must contain a maximum of {OrderConstraintProperty.BarcodeMaximumLength} characters"
    });
    public static string BarcodeFormat = GetAsJson(new()
    {
        Ar = "الباركود يجب ان يحتوي على ارقام فقط",
        En = "Barcode must contain numbers only"
    });

    #endregion

    #region Notes

    public static string NotesMaximumLength = GetAsJson(new()
    {
        Ar = $"الملاحظات طويلة جدا, يجب ان تحتوي الملاحظات على اقل من {OrderConstraintProperty.NotesMaximumLength} حروف",
        En = $"Notes is too long, The notes must contain a maximum of {OrderConstraintProperty.NotesMaximumLength} characters"
    });

    #endregion

    #region DeliveryFare

    public static string DeliveryFareMinimumValue = GetAsJson(new()
    {
        Ar = $"قيمة الشحن يجب ان تكون اكبر من او تساوي{OrderConstraintProperty.DeliveryFareMinimumValue}",
        En = $"Delivery fare must be greater than or equal {OrderConstraintProperty.DeliveryFareMinimumValue}"
    });

    #endregion

    #region Discount

    public static string DiscountMinimumValue = GetAsJson(new()
    {
        Ar = $"قيمة الخصم يجب ان تكون اكبر من او تساوي {OrderConstraintProperty.DiscountMinimumValue}",
        En = $"Discount must be greater than or equal {OrderConstraintProperty.DiscountMinimumValue}"
    });

    #endregion

    #region Address

    public static string AddressMaximumLength = GetAsJson(new()
    {
        Ar = $"العنوان طويل جدا, يجب ان يحتوي العنوان على اقل من {OrderConstraintProperty.AddressMaximumLength} حروف",
        En = $"Address is too long, The address must contain a maximum of {OrderConstraintProperty.AddressMaximumLength} characters"
    });

    //required
    public static string AddressRequired = GetAsJson(new()
    {
        Ar = "العنوان مطلوب",
        En = "Address is required"
    });

    #endregion
}
