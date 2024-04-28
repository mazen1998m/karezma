namespace App.Domain.Orders;

public class OrderConstraintProperty
{

    //public string Barcode { get; set; }
    //public string Notes { get; set; }
    //public decimal DeliveryFare { get; set; }
    //public decimal? Discount { get; set; }
    //public string Address { get; set; }

    #region Barcode
    public static int BarcodeMaximumLength = 50;
    public static string BarcodeFormat = @"^\d+$";
    #endregion

    #region Notes
    public static int NotesMaximumLength = 500;
    #endregion

    #region DeliveryFare
    public static decimal DeliveryFareMinimumValue = 0;
    #endregion

    #region Discount
    public static decimal DiscountMinimumValue = 0;
    #endregion

    #region Address
    public static int AddressMaximumLength = 500;
    #endregion


}
