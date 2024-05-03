namespace App.core.Common;

public class Base64Data
{
    public readonly byte[] Bytes;

    public readonly string Extension;

    public Base64Data(string base64String)
    {
        try
        {
            Extension = base64String.Split(';')[0].Split('/')[1];
            Bytes = Convert.FromBase64String(base64String.Split(',')[1]);
        }
        catch
        {
            throw new ArgumentException("invalid base64 string");
        }
    }
}