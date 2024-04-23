using App.Application.Const;

namespace App.Application.Representatives.Validator;

public class RepresentativeErrorMessage : ValidatorErrorMessage
{
    #region Representative

    #region UserName
    public static string UserNameRequired = "Username is required";
    public static string UsernameIsUesd = "Username is uesd";
    public static string UsernameMaximumLength = $"Username is too long , The username must contain a maximum of {ConstraintProperty.UserNameMaximumLength} characters";
    public static string UsernameMinimumLength = $"Username is too short, the username must contain at least {ConstraintProperty.UserNameMinimumLength} characters ";
    #endregion

    #region Name
    public static string NameRequired = "Name is required";
    public static string NameMaximumLength = $"Name is too long, The name must contain a maximum of {ConstraintProperty.NameMaximumLength} characters";
    public static string NameMinimumLength = $"Name is too short , the name must contain at least {ConstraintProperty.NameMinimumLength} characters ";
    #endregion

    #region Phone
    public static string PhoneRequired = "Phone is required";


    public static string PhoneMatches = "Phone is not valid, The phone number must be a number and start with 077, 078 or 079";
    public static string PhoneLength = GetAsJson(new()
    {
        Ar = "خطء",
        En = $"Phone must be {ConstraintProperty.PhoneLength} characters"
    });
    //$"Phone must be {ConstraintProperty.PhoneLength} characters";

    #endregion

    #region Commision
    public static string CommisionMinimum = $"Commision must be at least {ConstraintProperty.CommisionMinimum}";
    #endregion

    #endregion


}
