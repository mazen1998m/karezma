namespace App.Domain.Products.Dtos;

public class ProductUpdateDto : Dto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Barcod { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
