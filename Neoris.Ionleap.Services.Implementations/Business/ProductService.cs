using System;
using System.Collections.Generic;
using System.Text;
using Neoris.Ionleap.Business.Logic.Abstractions.Business;
using Neoris.Ionleap.Business.Logic.Implementations.Business;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Business;
using Neoris.Ionleap.Services.Abstractions.Business;
using Neoris.Ionleap.Services.Implementations.Infrastructure;

namespace Neoris.Ionleap.Services.Implementations.Business
{
    public class ProductService : EntityManagerService<Product, ProductLogic, IonleapContext>, IProductService
    {
        private IProductLogic _productLogic;
        public IProductLogic ProductLogic
        {
            get
            {
                return this._productLogic ??= new ProductLogic();
            }
        }

        public void DeliverProductsWebsite(string productsUrl, string token)
        {
            try
            {
                this.ProductLogic.DeliverProductsWebsite(productsUrl, token);
            }
            catch (Exception e)
            {
                this.HandleException(e);
                throw e;
            }
        }
    }
}
