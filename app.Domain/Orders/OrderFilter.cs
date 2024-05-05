namespace App.Domain.Orders;

using App.Domain.Enums;
using Lampda = Expression<Func<Order, bool>>;
public class OrderFilter : Filter<Order>
{
    public string RepresentativeName { get; set; }
    public string Barcode { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }


    public Lampda _RepresentativeName() => x => x.Representative.UserInfo.Name == RepresentativeName;
    public Lampda _Barcode() => x => x.Barcode == Barcode;
    public Lampda _Status() => x => x.OrderStatus == Status;

    public Lampda _FromDate() => x => x.CreatedDate >= FromDate;
    public Lampda _ToDate() => x => x.CreatedDate <= ToDate.AddDays(1);


    protected override void ApplyFilter()
    {
        AddFilter(RepresentativeName is not null, _RepresentativeName());
        AddFilter(Barcode is not null, _Barcode());
        AddFilter(Status is not 0, _Status());
        AddFilter(FromDate != DateTime.MinValue, _FromDate());
        AddFilter(ToDate != DateTime.MinValue, _ToDate());

    }
}
