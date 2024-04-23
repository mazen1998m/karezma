using System.Collections;

namespace App.core.Extensions;

public static class ObjectExtensions
{
    public static bool IsObjEmpty<T>(this T obj)
    {

        if (obj == null) return true;
        var objType = obj.GetType();

        if (obj is ICollection collection)
        {
            var flag1 = true;
            foreach (var o in collection)
            {
                var properties1 = o!.GetType().GetProperties();

                foreach (var property in properties1)
                {
                    var propertyValue = property.GetValue(o);
                    flag1 = flag1 && propertyValue!.IsEmpty();
                }

            }

            return flag1;
        }

        var properties = obj!.GetType().GetProperties();
        var flag = true;
        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(obj);
            flag = flag && propertyValue!.IsEmpty();
        }

        return flag;
    }
}



