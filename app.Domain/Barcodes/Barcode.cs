namespace App.Domain.Barcodes;

public class Barcode : Entity
{

    public string FromCode { get; set; }
    public string ToCode { get; set; }
    public string LastCodeUsed { get; set; }

    public string NumberOfCodeAvailable { get; set; }

    internal class Configuration : ConfigureTable<Barcode>
    {
        protected override void ConfigureCustomizations()
        {

        }
    }
}
