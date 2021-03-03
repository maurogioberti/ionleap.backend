using System;
using System.Collections.Generic;
using System.Text;
using Neoris.Ionleap.Business.Logic.Abstractions.Business;
using Neoris.Ionleap.ResourceAccess.Entities.Business;
using Neoris.Ionleap.Services.Abstractions.Infrastructure;

namespace Neoris.Ionleap.Services.Abstractions.Business
{
    public interface IProductService : IEntityManagerService<Product, IProductLogic>
    {
        public void DeliverProductsWebsite(string productsUrl, string token);
    }
}