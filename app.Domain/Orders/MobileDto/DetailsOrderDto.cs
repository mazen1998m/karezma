using App.Domain.Clints.Dtos;
using App.Domain.Enums;
using App.Domain.OrderProducts.Dtos;

namespace App.Domain.Orders.MobileDto;

public class DetailsOrderDto : Dto
{
    public DetailsClintDto Clint { get; set; }
    public List<DetailsOrderProductDto> Products { get; set; }
    public string Notes { get; set; }
    public decimal DeliveryFare { get; set; }
    public decimal TotalPrice { get; set; }

    public decimal Price { get; set; }

    public string Address { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string Title { get; set; }
    public decimal Discount { get; set; }
    public string SalesmanName { get; set; }


}
