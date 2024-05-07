using App.Domain.Orders;

namespace App.Application.Orders;

internal class OrderService : Service<Order>, IOderService
{
    private readonly IRepository<Order> _repository;

    public OrderService(IRepository<Order> repository) : base(repository)
    {
        this._repository = repository;
    }


    public async Task<OrderStatus> ChangeStatus(int id, OrderStatus status)
    {
        try
        {
            var order = await _repository.GetByIdAsync(id);
            order.OrderStatus = status;
            await _repository.SaveUpdateAsync(order);
            return order.OrderStatus;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async override Task<Result<TMap>> SoftDeleteByIdAsync<TMap>(int id)
    {
        var orderStatus = await _repository.FirstOrDefaultAsync(o => o.Id == id, s => new { s.Id, s.OrderStatus });
        if (orderStatus.OrderStatus == OrderStatus.Pending || orderStatus.OrderStatus == OrderStatus.Reject)
        {
            return await base.SoftDeleteByIdAsync<TMap>(id);
        }

        return Result<TMap>.Fail("Can not delete order");

    }


}

public interface IOderService : IService<Order>
{
    Task<OrderStatus> ChangeStatus(int id, OrderStatus status);
}
