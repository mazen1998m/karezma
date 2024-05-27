using App.Domain.OrderProducts;
using App.Domain.Orders;
using App.Domain.Orders.Dtos;

namespace App.Application.Orders;

internal class OrderService : Service<Order>, IOderService
{
    private readonly IRepository<Order> _repository;
    private readonly IRepository<OrderProduct> _orderProductRepository;
    private readonly IMapper _mapper;

    public OrderService(IRepository<Order> repository, IRepository<OrderProduct> orderProductRepository, IMapper mapper) : base(repository)
    {
        this._repository = repository;
        _orderProductRepository = orderProductRepository;
        _mapper = mapper;
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

    public async Task<Result<UpdateOrderDto>> UpdateOrderAsync(UpdateOrderDto dto)
    {
        try
        {
            var r = (await _repository.FirstOrDefaultAsync(x => x.Id == dto.Id, s => new { dto.Id, s.RepresentativeId, s.OrderStatus }));
            var oldOrderProduct = await _orderProductRepository.GetAllAsync(x => x.OrderId == dto.Id);
            _ = _orderProductRepository.SaveDeleteRangeAsync(oldOrderProduct);
            dto.RepresentativeId = r.RepresentativeId;
            dto.OrderStatus = r.OrderStatus;

            return await base.UpdateAsync(dto);
        }
        catch (Exception)
        {
            return default;
        }
    }


}

public interface IOderService : IService<Order>
{
    Task<OrderStatus> ChangeStatus(int id, OrderStatus status);
    Task<Result<UpdateOrderDto>> UpdateOrderAsync(UpdateOrderDto dto);
}
