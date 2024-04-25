namespace App.Domain.Products.Dtos;

public class DetailsProductDto : Dto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Barcode { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

}
