namespace App.Application.Representatives.Validator;

public class RepresentativeConstraintProperty
{

    #region UserName
    public static int UserNameMaximumLength = 50;
    public static int UserNameMinimumLength = 3;
    #endregion

    #region Name
    public static int NameMaximumLength = 50;
    public static int NameMinimumLength = 3;
    #endregion

    #region Phone
    public static int PhoneLength = 10;
    public static string PhoneMatches = @"^(077|078|079)\d*$";
    #endregion

    #region Commision
    public static double CommisionMinimum = 0;
    #endregion

}
