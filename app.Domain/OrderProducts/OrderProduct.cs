using App.Domain.Orders;
using App.Domain.Products;

namespace App.Domain.OrderProducts;

public class OrderProduct : Entity
{

    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Notes { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }

    internal class Configuration : ConfigureTable<OrderProduct>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

        }
    }

}
