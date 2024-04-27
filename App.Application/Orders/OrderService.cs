using App.Data.GenericRepository;
using App.Domain.Constants.Enums;
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
}

public interface IOderService : IService<Order>
{
    Task<OrderStatus> ChangeStatus(int id, OrderStatus status);
}
