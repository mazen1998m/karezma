namespace App.core.Extensions;

public static class IntExtensions
{

    public static int NotNull(this int? @int)
    {

        if (@int == null) return default; return @int.Value;

    }

    public static bool IsNull(this int? @int)
    {

        if (@int == null) return true; return false;

    }

    public static string NotNull(this string? @string)
    {

        if (@string == null) return ""; return @string;

    }

}
