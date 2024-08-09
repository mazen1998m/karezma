namespace App.core.Extensions;

public static class StringExtensions
{
    //convert string to int
    public static int ToInt(this string value)
    {
        return int.TryParse(value, out var result) ? result : 0;
    }
}
