namespace App.Data.GenericRepository.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(object obj) : base(ExceptionErrorMassage.NotFoundException(obj))
    {
    }
}