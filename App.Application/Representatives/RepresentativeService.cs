using App.core.Extensions;
using App.Data.GenericRepository;
using App.Domain.Enums;
using App.Domain.Orders;
using App.Domain.Representatives;
using App.Domain.Users.Auths;

namespace App.Application.Representatives;

internal class RepresentativeService : Service<Representative>, IRepresentativeService
{
    private readonly IRepository<Order> _orderRepository;

    public IRepository<Representative> _repository { get; }
    public RepresentativeService(IRepository<Representative> repository, IRepository<Order> orderRepository) : base(repository)
    {
        _repository = repository;
        _orderRepository = orderRepository;
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
            var orders = await _orderRepository.FindAsync(x => x.RepresentativeId == id && x.OrderStatus == OrderStatus.Delivered);

            if (!orders.Any()) return false;

            orders.ForEach(x => x.OrderStatus = OrderStatus.Paid);

            await _orderRepository.SaveUpdateRangeAsync(orders);

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