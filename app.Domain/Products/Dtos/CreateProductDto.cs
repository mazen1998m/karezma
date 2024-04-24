namespace App.Domain.Products.Dtos;

public class CreateProductDto : Dto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Barcode { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
}
