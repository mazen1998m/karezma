namespace App.Domain.Clints;


//rename to Customer
public class Clint : Entity
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string SecandPhone { get; set; }
    public decimal Weight { get; set; }
    public decimal Hight { get; set; }

    internal class Configuration : ConfigureTable<Clint>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(x => x.Weight).HasColumnType("decimal(18,2)");
            Builder.Property(x => x.Hight).HasColumnType("decimal(18,2)");

        }
    }
}
