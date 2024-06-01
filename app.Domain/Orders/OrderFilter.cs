namespace App.Domain.Orders;

using App.core.Helpers;
using App.core.InjectionHelper;
using App.Domain.Enums;
using Muslim.Filter.Enums;
using Lampda = Expression<Func<Order, bool>>;
public class OrderFilter : Filter<Order>
{
    public ICurrentUser _currentUser { get; set; }
    public OrderFilter()
    {
        SortColumn = "CreatedDate";
        SortDirection = Direction.Desc;
        _currentUser = _currentUser.Inject();
    }
    public string ClintPhone { get; set; }
    public string Barcode { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }


    public Lampda _ClintName() => x => x.Clint.Phone.Contains(ClintPhone);
    public Lampda _Barcode() => x => x.Barcode == Barcode;
    public Lampda _Status() => x => x.OrderStatus == Status;

    public Lampda _FromDate() => x => x.CreatedDate >= FromDate;
    public Lampda _ToDate() => x => x.CreatedDate <= ToDate.AddDays(1);

    public Lampda _GetOrderByCurruntUser() => x => x.Representative.UserInfo.Id == _currentUser.UserId;

    protected override void ApplyFilter()
    {
        if (Barcode == "non") Barcode = null;
        AddFilter(!_currentUser.IsAdmin, _GetOrderByCurruntUser());

        AddFilter(ClintPhone is not null, _ClintName());
        AddFilter(Barcode is not null, _Barcode());
        AddFilter(Status != OrderStatus.non, _Status());
        AddFilter(FromDate != DateTime.MinValue, _FromDate());
        AddFilter(ToDate != DateTime.MinValue, _ToDate());

    }
}
