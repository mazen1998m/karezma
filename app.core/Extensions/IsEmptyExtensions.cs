namespace App.core.Extensions;

public static class IsEmptyExtensions
{

    public static bool IsEmpty<T>(this T @this)
    {
        if (@this == null)
            return true;
        return @this!.Equals(default);
    }



}