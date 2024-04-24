using Newtonsoft.Json;

namespace App.Application.Const;

public class ValidatorErrorMessage
{

    public static string GetAsJson(TraslateErrorMessage message) => JsonConvert.SerializeObject(message);


}


public class TraslateErrorMessage
{
    public string Ar { get; set; }
    public string En { get; set; }
}