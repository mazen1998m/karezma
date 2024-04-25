using App.Domain.Orders;
using App.Domain.Users;

namespace App.Domain.Representatives;

public class Representative : Entity
{
    public double Commision { get; set; }

    public User? UserInfo { get; set; }

    public ICollection<Order> Orders { get; set; }

    internal class Configuration : ConfigureTable<Representative>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(x => x.Commision).IsRequired();

        }
    }

}
