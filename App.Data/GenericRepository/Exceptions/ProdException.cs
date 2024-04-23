using System.Linq.Expressions;

namespace App.Data.GenericRepository.Exceptions;

public static class ProdException
{
    public static bool And(this bool left, bool right) => left && right;
    public static bool Or(this bool left, bool right) => left || right;



    public static bool If<T>(this T left, Expression<Func<T, bool>> right) where T : new()
    {

        return right.Compile().Invoke(left);

    }

    public static IQueryable<TSource> And<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
    {
        source.If(null).Throw(new ArgumentNullException(nameof(source)));
        predicate.If(null).Throw(new ArgumentNullException(nameof(predicate)));



        return source.Where(predicate);
    }




    //where return IEnumerable<Type>


    //public static bool Or<T>(this object left, Expression<Func<T, bool>> right)
    //{
    //    // extract property name and value from the lambda expression
    //    var binaryExpression = (BinaryExpression)right.Body;
    //    var propertyName = ((MemberExpression)binaryExpression.Left).Member.Name;
    //    var propertyValue = Expression.Lambda(binaryExpression.Right).Compile().DynamicInvoke();

    //    // get the property value of the left object using reflection
    //    var leftType = left.GetType();
    //    var property = leftType.GetProperty(propertyName);
    //    var leftValue = property.GetValue(left);

    //    // handle different cases depending on the type of the left value
    //    if (leftValue == null)
    //    {
    //        return propertyValue == null;
    //    }
    //    else if (leftValue is T leftTValue)
    //    {
    //        return leftTValue.Equals(propertyValue);
    //    }
    //    else if (leftValue.GetType().IsGenericType && leftValue.GetType().GetGenericTypeDefinition() == typeof(Nullable<>))
    //    {
    //        var underlyingType = Nullable.GetUnderlyingType(leftValue.GetType());
    //        if (underlyingType == typeof(T))
    //        {
    //            return leftValue.Equals(propertyValue);
    //        }
    //        else
    //        {
    //            var nullableLeftValue = Convert.ChangeType(leftValue, underlyingType);
    //            var nullablePropertyValue = Convert.ChangeType(propertyValue, underlyingType);
    //            return nullableLeftValue.Equals(nullablePropertyValue);
    //        }
    //    }
    //    else
    //    {
    //        var convertedPropertyValue = Convert.ChangeType(propertyValue, property.PropertyType);
    //        return leftValue.Equals(convertedPropertyValue);
    //    }
    //}








    public static bool AndNot(this bool left, bool right)
    {


        return left && !right;
    }

    public static bool OrNot(this bool left, bool right)
    {
        return left || !right;
    }

    public static int And(this int left, int right)
    {
        return left + right;
    }



    public static bool If(this IQueryable queryable, object? o)
    {
        return Equals(queryable, o) ? true : false;
    }

    public static bool If<TType>(this Expression<Func<TType, bool>> queryable, object? o)
    {
        return Equals(queryable, o) ? true : false;
    }


    public static void Throw(this bool condition, Exception exception)
    {
        if (condition)
            throw exception;
    }




}

