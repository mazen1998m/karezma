using App.Domain.Orders;

namespace App.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Barcode { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }


    internal class Configuration : ConfigureTable<Product>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.HasIndex(c => new { c.Name, c.IsDeleted }).IsUnique();
            Builder.HasIndex(c => new { c.Model, c.IsDeleted }).IsUnique();

            Builder.Property(u => u.Name).IsRequired().HasMaxLength(OrderConstraintProperty.NameMaximumLength);
            Builder.Property(u => u.Model).IsRequired().HasMaxLength(OrderConstraintProperty.ModelMaximumLength);
            Builder.Property(u => u.Barcode).HasMaxLength(OrderConstraintProperty.BarcodeMaximumLength);
            Builder.Property(u => u.Description).HasMaxLength(OrderConstraintProperty.DescriptionMaximumLength);
            Builder.Property(u => u.IsActive).HasDefaultValue(true);





        }
    }
}
