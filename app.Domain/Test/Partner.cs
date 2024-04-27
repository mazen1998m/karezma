//namespace App.Domain.Test;

//public class Partner : Entity
//{


//    public string ArName { get; set; }
//    public string EnName { get; set; }
//    public PartnerType? Type { get; set; }
//    public int? TypeId { get; set; }
//    public List<ShopType> ShopTypes { get; set; }
//    public string Link { get; set; }
//    public string PromoCode { get; set; }
//    public string ComercialRegistrationNo { get; set; }

//    public PartnerRepresentative PartnerRepresentative { get; set; }
//    public List<Sector> Sectors { get; set; }
//    public string Logo { get; set; }
//    public List<PartnerAddress> Addresses { get; set; }
//    public string EnShippingAreas { get; set; }
//    public string ArShippingAreas { get; set; }
//    public bool IsAproved { get; set; }
//    public bool IsActive { get; set; }

//    internal class Configuration : ConfigureTable<Partner>
//    {
//        protected override void ConfigureCustomizations()
//        {
//            Builder.HasOne(x => x.Type).WithMany(x => x!.Partners).HasForeignKey(x => x.TypeId);

//            Builder.HasMany(x => x.ShopTypes).WithMany(x => x!.Partners);

//            Builder.HasMany(x => x.Sectors).WithMany(x => x!.Partners);
//            Builder.HasMany(x => x.Addresses).WithOne(x => x!.Partner).HasForeignKey(x => x.PartnerId);

//        }
//    }

//}

