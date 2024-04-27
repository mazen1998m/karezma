namespace App.Domain.OrderProducts.Dtos;

public class CreateOrderProductDto : Dto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Notes { get; set; }
}
