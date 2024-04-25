using Newtonsoft.Json;

namespace App.core.ValidatorHelper;

public class ValidatorErrorMessage
{

    public static string GetAsJson(TraslateErrorMessage message) => JsonConvert.SerializeObject(message);


}


public class TraslateErrorMessage
{
    public string Ar { get; set; }
    public string En { get; set; }
}