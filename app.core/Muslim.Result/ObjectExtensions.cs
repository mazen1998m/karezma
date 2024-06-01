using System.Collections;

namespace App.core.Muslim.Result;

internal static class ObjectExtensions
{
    public static bool IsObjEmpty<T>(this T obj)
    {

        if (obj == null) return true;

        if (obj is ICollection collection)
        {
            var flag1 = true;
            foreach (var o in collection)
            {
                var properties1 = o!.GetType().GetProperties();

                flag1 = properties1.Select(property => property.GetValue(o)).Aggregate(flag1, (current, propertyValue) => current && propertyValue!.IsEmpty());
            }

            return flag1;
        }

        var properties = obj.GetType().GetProperties();

        return properties.Select(property => property.GetValue(obj)).Aggregate(true, (current, propertyValue) => current && propertyValue!.IsEmpty());
    }

    private static bool IsEmpty<T>(this T @this)
    {
        if (@this != null) return @this!.Equals(default);
        return true;
    }
}



