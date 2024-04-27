namespace App.Domain.Clints;

public class ClintConstraintProperty
{
    #region Name
    public static int NameMaximumLength = 50;
    public static int NameMinimumLength = 3;
    #endregion

    #region Phone
    public static int PhoneLength = 10;
    public static string PhoneFormat = @"^(077|078|079)\d*$";
    #endregion

    #region SecandPhone
    public static int SecandPhoneLength = 10;
    public static string SecandPhoneFormat = @"^(077|078|079)\d*$";
    #endregion

    #region Weight
    public static decimal WeightMinimum = 0;
    #endregion

    #region Hight
    public static decimal HightMinimum = 0;
    #endregion

}
