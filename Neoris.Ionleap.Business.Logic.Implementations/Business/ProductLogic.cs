using Neoris.Ionleap.Business.Logic.Abstractions.Business;
using Neoris.Ionleap.Business.Logic.Implementations.Infrastructure;
using Neoris.Ionleap.CrossCutting.Utils.Http;
using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Business;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Business;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Business;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Neoris.Ionleap.Business.Logic.Implementations.Business
{
    public class ProductLogic : EntityManagerLogic<Product, IonleapContext>, IProductLogic
    {
        private IProductAdapter _productAdapter;
        protected IProductAdapter ProductAdapter => _productAdapter ??= new ProductAdapter();

        private IBrandLogic _brandLogic;
        protected IBrandLogic BrandLogic => _brandLogic ??= new BrandLogic();

        private ICategoryLogic _categoryLogicLogic;
        protected ICategoryLogic CategoryLogic => _categoryLogicLogic ??= new CategoryLogic();

        public List<Product> GetByWebsite()
        {
            try
            {
                List<Product> products = ProductAdapter.GetAll().Where(p => p.WebSite).ToList();

                return products;
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return null;
        }

        public void DeliverProductsWebsite(string productsUrl, string token)
        {
            try
            {
                List<Product> productsList = this.GetByWebsite();

                foreach (Product product in productsList)
                {
                    product.WebSiteToken = token;
                    this.DeliverProductWebsiteRequest(product, productsUrl);
                }

            }
            catch (Exception e)
            {
                this.HandleException(e);
                throw e;
            }
        }

        private void DeliverProductWebsiteRequest(object obj, string url)
        {
            BaseHttpRequest.HttpPostRequest(url, obj);
        }

    }
}
