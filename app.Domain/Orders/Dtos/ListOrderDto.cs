using App.Domain.Clints.Dtos;

namespace App.Domain.Orders.Dtos;

public class ListOrderDto : Dto
{
    public string RepresentativeName { get; set; }
    public ListClintDto Clint { get; set; }
    public string Address { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string OrderStatus { get; set; }

    public DateTime CreatedDate { get; set; }

}
