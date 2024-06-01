using Muslim.ValidatorErrors;

namespace App.core.Muslim.Result;

/// <summary>
/// Represents the result of an operation that returns an object of type <typeparamref name="TYpe"/>.
/// </summary>
/// <typeparam name="TYpe">The type of the object returned by the operation.</typeparam>
public class Result<TYpe>
{
    #region prop
    public TYpe? Response { get; set; }
    public List<string> Error { get; private set; }
    public List<ValidatorError> ValidatorError { get; set; }
    public bool IsSuccess { get; set; }
    public ResultPage Page { get; set; }

    public object Filter { get; set; }

    #endregion

    #region Errors
    public Result<TYpe> AddError(string errorMessage)
    {
        Error ??= new List<string>();
        Error.Add(errorMessage);
        return this;
    }

    public Result<TYpe> AddValidateError(string propName, string errorMessage)
    {
        ValidatorError ??= new List<ValidatorError>();

        ValidatorError.Add(new ValidatorError { PropertyName = propName, ErrorMessage = errorMessage });

        IsSuccess = false;

        return this;

    }

    public static Result<TYpe> Exception(Exception e) => CreateExceptionResult(e);

    public Result<TYpe> Exception(Exception e, int overrite = 0) => AddError(e.Message);



    #endregion

    #region status

    public static Result<TYpe> Success() => new() { IsSuccess = true, };

    public static Result<TYpe> Success(TYpe response) => new()
    {
        Response = response,
        IsSuccess = true,
    };

    public static Result<TYpe> Success(TYpe response, ResultPage page) => new()
    {
        Response = response,
        IsSuccess = true,
        Page = page
    };

    public static Result<TYpe> Success(TYpe response, int count, int pageSize) => new()
    {
        Response = response,
        IsSuccess = true,
        Page = ResultPage.Create(count, pageSize)
    };


    public static Result<TYpe> Fail(string errorMessage = "") => new()
    {

        Response = default,
        IsSuccess = false,
        Error = new List<string> { errorMessage == "" ? Message.UnspecifiedError : errorMessage },

    };

    public static Result<TYpe> ValidatorFail(List<ValidatorError> validatorErrors)
    {
        return new Result<TYpe>
        {
            ValidatorError = validatorErrors,
            IsSuccess = false,
            Response = default,
            Error = default
        };

    }



    #endregion

    public Result<TOType> To<TOType>(TOType toResult)
    {
        return new Result<TOType>
        {
            Response = toResult,
            IsSuccess = IsSuccess,
            ValidatorError = ValidatorError,
            Error = Error,
            Page = Page
        };
    }

    #region  CreateResult
    public static Result<TYpe> Create(TYpe obj, ResultPage resultPage = default!) =>
              obj.IsObjEmpty()
                        ? CreateResultToNullObj()
                        : CreateResultToNotNullObj(obj, resultPage);

    public static Result<TYpe> Create() => CreateResultToNullObj();

    public static Task<Result<TYpe>> Create(Task<TYpe> obj) =>
        obj.IsObjEmpty()
            ? CreateResultToNullObjAsync()
            : CreateResultToNotNullObjAsync(obj);

    public static Result<TYpe> Create(TYpe obj) =>
        obj.IsObjEmpty()
            ? CreateResultToNullObj()
            : CreateResultToNotNullObj(obj);

    public static Result<TYpe> Create(List<ValidatorError> validatorErrors, object entity, TYpe dto
        , string errorMessage = null!)
    {
        return new Result<TYpe>
        {
            ValidatorError = validatorErrors,
            IsSuccess = entity != null!,
            Response = entity != null! ? dto : default,
            Error = entity == null! ? errorMessage == null! ? default : new List<string> { Message.NoError } : default
        };

    }

    public static Result<TYpe> Create(List<ValidatorError> validatorErrors, TYpe dto
        , string errorMessage = null!)
    {
        return new Result<TYpe>
        {
            ValidatorError = validatorErrors,
            IsSuccess = dto != null!,
            Response = dto != null! ? dto : default,
            Error = dto == null!
                ?
                    errorMessage == null!
                        ? new List<string> { Message.NotFound }
                        : new List<string> { errorMessage }

                : default
        };

    }

    #region helper methods to create result


    private static async Task<Result<TYpe>> CreateResultToNotNullObjAsync(Task<TYpe> obj)
    {
        return await Task.FromResult(new Result<TYpe>
        {
            Response = await obj,
            IsSuccess = true,
            Error = default,
        });
    }

    private static async Task<Result<TYpe>> CreateResultToNullObjAsync()
    {
        return await Task.FromResult(new Result<TYpe>
        {
            IsSuccess = false,
            Error = new List<string> { Message.NotFound }
        });
    }

    private static Result<TYpe> CreateResultToNotNullObj(TYpe obj, ResultPage resultPage = default!) => new()
    {
        Response = obj,
        IsSuccess = true,
        Page = resultPage

    };

    private static Result<TYpe> CreateExceptionResult(Exception e)
    {
        var result = new Result<TYpe>()
        {
            Response = default,
            IsSuccess = false,
            Error = new List<string> { e.Message },

        };
        return result;
    }


    private static Result<TYpe> CreateResultToNullObj() => new()
    {
        Response = default!,
        IsSuccess = false,
        Error = new List<string> { Message.NotFound },
        Page = new ResultPage()
    };
    #endregion


    #endregion
}

