namespace App.Application.Const;

public class ValidatorErrorMessage
{

    public static string GetAsJson(TraslateErrorMessage message)
    {

        return $"{{ar:\"{message.Ar}\",en:\"{message.En}\"}}";
    }


}


public class TraslateErrorMessage
{
    public string Ar { get; set; }
    public string En { get; set; }
}