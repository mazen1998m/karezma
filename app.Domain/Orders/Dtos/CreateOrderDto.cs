using App.Domain.Clints.Dtos;
using App.Domain.OrderProducts.Dtos;

namespace App.Domain.Orders.Dtos;

public class CreateOrderDto : Dto
{
    public CreateClintDto Clint { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
    public decimal DeliveryFare { get; set; }
    public decimal? Discount { get; set; }
    public List<CreateOrderProductDto> Products { get; set; }
}
