using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Ionleap.ResourceAccess.Entities.Business
{
    public partial class Product : BaseEntity
    {
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal PriceBusiness { get; set; }
        public int Quantity { get; set; }
        public bool WebSite { get; set; }
        public string Picture { get; set; }

        [Column("BrandId")]
        public int BrandIdentity { get; set; }

        [Column("CategoryId")]
        public int CategoryIdentity { get; set; }

    }

}