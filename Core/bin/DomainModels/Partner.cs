using Core.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainModels
{
    public class Partner : BaseEntityInt
    {
        public string ProductImage { get; set; }
        public string PartnerLogo { get; set; }
        public string ProductName { get; set; }
        public string ExternalLink { get; set; }
        public string PromoCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
