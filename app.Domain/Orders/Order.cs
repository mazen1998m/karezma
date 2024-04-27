using App.Domain.Clints;
using App.Domain.Constants.Enums;
using App.Domain.OrderProducts;
using App.Domain.Representatives;

namespace App.Domain.Orders;

public class Order : Entity
{
    //todo: order card dto
    //{ 
    //public string Title { get; set; }//addriess + clint name 
    //public decimal TotalPrice { get; set; }//calculate from OrderProduct.Price*OrderProduct.Quantity + delivery fare
    //}
    public Clint Clint { get; set; }
    public int ClintId { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }

    public string Barcode { get; set; }
    public string Notes { get; set; }
    public decimal DeliveryFare { get; set; }
    public decimal? Discount { get; set; }
    public string Address { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public int RepresentativeId { get; set; }
    public Representative Representative { get; set; }


    internal class Configuration : ConfigureTable<Order>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(x => x.DeliveryFare).HasColumnType("decimal(18,2)");
            Builder.Property(x => x.Discount).HasColumnType("decimal(18,2)");
        }
    }
}
