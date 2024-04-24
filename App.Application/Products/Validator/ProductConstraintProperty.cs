namespace App.Application.Products.Validator;

public class ProductConstraintProperty
{



    #region Name
    public static int NameMaximumLength = 50;
    public static int NameMinimumLength = 3;
    #endregion

    #region Model
    public static int ModelMaximumLength = 50;
    public static int ModelMinimumLength = 3;
    #endregion

    #region Barcode
    public static int BarcodeMaximumLength = 50;
    public static int BarcodeMinimumLength = 3;
    public static string BarcodeFormat = @"^\d+$";
    #endregion

    #region Description
    public static int DescriptionMaximumLength = 500;
    #endregion




}
