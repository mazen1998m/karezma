namespace App.core.Extensions;

public static class ExtensionsEnum
{
    public static T ToEnum<T>(this string value) where T : struct
    {
        if (Enum.TryParse<T>(value, out T result))
        {
            return result;
        }
        else
        {
            throw new ArgumentException($"Invalid value '{value}' for enum type {typeof(T).Name}");
        }
    }
}