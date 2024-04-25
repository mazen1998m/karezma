namespace App.Domain.Products.Dtos;

public class ListProductDto : Dto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Barcode { get; set; }
}
