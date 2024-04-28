namespace App.Domain.OrderProducts;

public class OrderProductConstraintProperty
{

    #region Quantity
    public static int QuantityMinimumValue = 1;
    #endregion

    #region Price
    public static decimal PriceMinimumValue = 0;
    public static decimal PriceMaximumValue = 1000000;
    #endregion

    #region Notes
    public static int NotesMaximumLength = 500;
    #endregion




}
