namespace App.Domain.Products;

using Lambda = Expression<Func<Product, bool>>;

public class ProductFilter : Filter<Product>
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Barcode { get; set; }

    protected Lambda _Name() => p => p.Name.Contains(Name);
    protected Lambda _Model() => p => p.Model.Contains(Model);
    protected Lambda _Barcod() => p => p.Barcode.Contains(Barcode);


    protected override void ApplyFilter()
    {
        AddFilter(Name is not null, _Name());
        AddFilter(Model is not null, _Model());
        AddFilter(Barcode is not null, _Barcod());
    }
}

