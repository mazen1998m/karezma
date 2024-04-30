using App.Domain.Clints.Dtos;
using App.Domain.Constants.Enums;
using App.Domain.OrderProducts.Dtos;

namespace App.Domain.Orders.Dtos;

public class DetailsOrderDto : Dto
{
    public DetailsClintDto Clint { get; set; }
    public List<DetailsOrderProductDto> Products { get; set; }
    public string Barcode { get; set; }//hidin input
    public string Notes { get; set; }
    public decimal DeliveryFare { get; set; }
    public decimal TotalPrice { get; set; }
    public string Address { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string Title { get; set; }
    public decimal Discount { get; set; }


}
