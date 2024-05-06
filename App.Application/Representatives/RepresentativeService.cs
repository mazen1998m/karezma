using App.core.Extensions;
using App.Data.GenericRepository;
using App.Domain.Enums;
using App.Domain.Representatives;
using App.Domain.Users.Auths;

namespace App.Application.Representatives;

internal class RepresentativeService : Service<Representative>, IRepresentativeService
{
    public IRepository<Representative> _repository { get; }
    public RepresentativeService(IRepository<Representative> repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Result<ResetPassword>> ResetPassword(ResetPassword resetPassword)
    {

        try
        {
            var validatorError = ValidateResult.Errors(resetPassword, out var isValid);

            var result = Result<ResetPassword>.ValidatorFail(validatorError);

            if (!isValid)
            {
                result.Response = resetPassword;
                return result;
            }

            var user = await _repository.GetByIdAsync<Representative>(resetPassword.Id);

            if (user == null) return Result<ResetPassword>.Fail("User is not exist");

            user.UserInfo.Password = resetPassword.NewPassword.ComputeSha256Hash();

            await _repository.SaveUpdateAsync(user);

            return Result<ResetPassword>.Success();


        }
        catch (Exception e)
        {
            return Result<ResetPassword>.Exception(e);
        }

    }


    public async Task<bool> Pay(int id)
    {
        try
        {
            var representative = await _repository.FirstOrDefaultAsync
                (x => x.Id == id && x.Orders.Any(x => x.OrderStatus == OrderStatus.Delivered));

            if (representative == null) return false;

            representative.Orders.ToList().ForEach(x => x.OrderStatus = OrderStatus.Paid);

            await _repository.SaveUpdateAsync(representative);

            return true;

        }
        catch (Exception e)
        {
            return false;
        }
    }

}


public interface IRepresentativeService : IService<Representative>
{
    Task<Result<ResetPassword>> ResetPassword(ResetPassword resetPassword);
    Task<bool> Pay(int id);
}