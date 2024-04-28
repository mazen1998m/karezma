

using App.Domain.Orders;
using App.Domain.Orders.Dtos;

namespace App.web.Controllers;

public class OrderController : ApiController<Order, CreateOrderDto, UpdateOrderDto>
{
    public OrderController(IService<Order> service) : base(service)
    {
    }

    //we need to check if can be deleted or not
}
