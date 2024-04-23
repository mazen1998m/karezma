namespace App.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Barcod { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }


    internal class Configuration : ConfigureTable<Product>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(u => u.IsActive).HasDefaultValue(true);
        }
    }
}
