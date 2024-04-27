//namespace App.Domain.Test;


//public class PartnerRepresentative : Entity
//{

//    public string EnName { get; set; }
//    public string ArName { get; set; }
//    public string Phone { get; set; }
//    public string Email { get; set; }

//    public Partner Partner { get; set; }

//    internal class Configuration : ConfigureTable<PartnerRepresentative>
//    {
//        protected override void ConfigureCustomizations()
//        {
//            Builder
//           .HasOne(u => u.Partner)
//           .WithOne(up => up.PartnerRepresentative)
//           .HasForeignKey<Partner>(up => up.Id);
//        }
//    }
//}