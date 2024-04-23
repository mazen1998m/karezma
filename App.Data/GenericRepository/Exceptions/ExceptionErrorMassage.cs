namespace App.Data.GenericRepository.Exceptions;

public class ExceptionErrorMassage
{
    public static string ObjectNullException(object obj)
    {
        return obj is null
            ? throw new ArgumentNullException(obj!.GetType().Name)
            : $"this object of type {obj.GetType().Name} is null.";
    }

    public static string NotFoundException(object obj)
    {
        return obj is null
            ? throw new ArgumentNullException(obj!.GetType().Name)
            : $"There is no object of type {obj.GetType().Name} ";
    }
}