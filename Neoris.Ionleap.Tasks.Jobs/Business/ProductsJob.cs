using Neoris.Ionleap.CrossCutting.Configuration;
using Neoris.Ionleap.Services.Abstractions.Business;
using Quartz;
using System;
using System.Threading.Tasks;

namespace Neoris.Ionleap.Tasks.Jobs.Business
{
    public class ProductsJob : IJob
    {
        private IProductService _productService;

        public ProductsJob(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("WebSite Sync Products process started.");

            try
            {
                this._productService.DeliverProductsWebsite(ConfigurationModule.Scheduler.WebSiteProductsSyncJob_ProductsRequestUrl, ConfigurationModule.Scheduler.WebSiteProductsSyncJob_TokenRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            await Console.Out.WriteLineAsync("WebSite Sync Products process finished.");
        }
    }
}
