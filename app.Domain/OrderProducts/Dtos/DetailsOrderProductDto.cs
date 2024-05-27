namespace App.Domain.OrderProducts.Dtos;

public class DetailsOrderProductDto : Dto
{
    public string Image { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string Notes { get; set; }
    public decimal Price { get; set; }
    public string Model { get; set; }
    public int ProductId { get; set; }
}

