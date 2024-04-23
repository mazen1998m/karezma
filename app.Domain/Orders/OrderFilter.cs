namespace App.Domain.Orders;

using Lampda = Expression<Func<Order, bool>>;
public class OrderFilter : Filter<Order>
{
    public string? OrderNumber { get; set; }
    public string? IsDeleted { get; set; }

    public Lampda _OrderNumber() => x => true;
    /*x.OrderNumber.Contains(OrderNumber!);*/
    //public Lampda _IsDeleted() => x => x.IsDeleted == false;
    protected void ApplyFilter()
    {
        AddFilter(OrderNumber is not null, _OrderNumber());
        //AddFilter(IsDeleted is not null, _IsDeleted());
    }
}
