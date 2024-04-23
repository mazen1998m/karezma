using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Muslim.ValidatorErrors;


namespace App.core.ValidatorHelper;

public static class ValidateResult
{
    private static IServiceProvider _serviceProvider;

    public static void SetServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static List<ValidatorError> GetValidationResult<T>(T objectToValidate, out bool isValid)
    {
        var results = GetValidator<T>().Validate(objectToValidate);
        var errorList = results.Errors.Select(x => new ValidatorError
        {
            PropertyName = x.PropertyName,
            ErrorMessage = x.ErrorMessage
        }).ToList();
        isValid = results.IsValid;
        return errorList;
    }

    private static IValidator<TValidator> GetValidator<TValidator>()
    {

        var validator = _serviceProvider!.GetRequiredService<IValidator<TValidator>>();
        return validator;
    }


    public static List<ValidatorError> Errors<TDto>(TDto createDto, out bool isValid)
    {
        var validatorError = ValidatorError.CreateList();
        isValid = true;

        try
        {
            validatorError = GetValidationResult(createDto, out isValid);
        }
        catch (InvalidOperationException)
        {
            ValidatorError.DefaultError(validatorError);
        }

        return validatorError;
    }




}