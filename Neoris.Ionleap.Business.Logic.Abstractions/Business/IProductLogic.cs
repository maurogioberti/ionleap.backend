using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Business;
using System.Collections.Generic;

namespace Neoris.Ionleap.Business.Logic.Abstractions.Business
{
    public interface IProductLogic : IEntityManagerLogic<Product>
    {
        public List<Product> GetByWebsite();

        public void DeliverProductsWebsite(string productsUrl, string token);
    }
}
