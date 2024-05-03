namespace App.Application.Barcodes.Validator;

public class BarcodeErrorMessage : ValidatorErrorMessage
{
    public static string BarcodeFormat = GetAsJson(new()
    {
        Ar = "الباركود يجب ان يحتوي على ارقام فقط",
        En = "Barcode must contain numbers only"
    });

    //Required
    public static string CodeRequired = GetAsJson(new()
    {
        Ar = "الكود مطلوب",
        En = "Code is required"
    });

    public static string BarcodeNotEqual = GetAsJson(new()
    {
        Ar = "الباركودين يجب ان لا يكونوا متساوينz",
        En = "Barcodes must not be equal"
    });

    public static string ToCodeGreaterThanFromCode = GetAsJson(new()
    {
        Ar = "الباركود الى يجب ان يكون اكبر من الباركود من",
        En = "To barcode must be greater than from barcode"
    });

    //FromCode less than ToCode
    public static string FromCodeLessThanToCode = GetAsJson(new()
    {
        Ar = "الباركود من يجب ان يكون اقل من الباركود الى",
        En = "From barcode must be less than to barcode"
    });
}
