using App.Domain.Enums;

namespace App.Domain.Orders.MobileDto;

public class ListOrderDto : Dto
{
    public OrderStatus OrderStatus { get; set; }
    public string ClintName { get; set; }
    public List<string> Products { get; set; }
    public string Address { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedDate { get; set; }

}
