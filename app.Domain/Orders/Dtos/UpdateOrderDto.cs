using App.Domain.Clints.Dtos;
using App.Domain.Enums;
using App.Domain.OrderProducts.Dtos;

namespace App.Domain.Orders.Dtos;

public class UpdateOrderDto : Dto
{
    public UpdateClintDto Clint { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
    public decimal DeliveryFare { get; set; }
    public decimal? Discount { get; set; }
    public int RepresentativeId { get; set; }
    public OrderStatus OrderStatus { get; set; }


    public List<UpdateOrderProductDto> Products { get; set; }
}
