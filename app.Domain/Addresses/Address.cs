namespace App.Domain.Addresses;

public class Address : Entity
{
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Street { get; set; }
    public string? Lat { get; set; }
    public string? Lot { get; set; }

    internal class Configuration : ConfigureTable<Address>
    {
        protected override void ConfigureCustomizations()
        {
            //if we need to any Custom Configuration
        }

    }
}
