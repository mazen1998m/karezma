namespace App.Domain.Representatives;

using Lambda = Expression<Func<Representative, bool>>;

public class RepresentativeFilter : Filter<Representative>
{
    public double? Commision { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }


    public Lambda _Name() => x => x.UserInfo!.Name.Contains(Name!);
    public Lambda _Phone() => x => x.UserInfo!.Phone.Contains(Phone!);
    public Lambda _Email() => x => x.UserInfo!.Email.Contains(Email!);
    public Lambda _Commision() => x => x.Commision == Commision;



    protected override void ApplyFilter()
    {
        AddFilter(Name is not null, _Name());
        AddFilter(Phone is not null, _Phone());

        AddFilter(Email is not null, _Email());
        AddFilter(Commision is not null, _Commision());
    }
}

