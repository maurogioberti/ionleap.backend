using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Ionleap.ResourceAccess.Entities.Business
{
    public partial class Product : BaseEntity
    {
        [NotMapped]
        public Brand Brand { get; set; }

        [NotMapped]
        public Category Category { get; set; }

        [NotMapped]
        public string WebSiteToken { get; set; }

    }

}
