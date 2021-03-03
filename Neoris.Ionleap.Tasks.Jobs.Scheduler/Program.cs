using Neoris.Ionleap.CrossCutting.Configuration;
using Neoris.Ionleap.Services.Abstractions.Business;
using Neoris.Ionleap.Services.Implementations.Business;
using Neoris.Ionleap.Tasks.Jobs.Business;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace Neoris.Ionleap.Tasks.Jobs.Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureServices(new ServiceCollection());

            MainAsync().GetAwaiter().GetResult();

            Console.ReadLine();
        }

        private static async Task MainAsync()
        {
            var jobDetails = JobBuilder.Create<ProductsJob>()
                .WithIdentity(JobKey.Create(ConfigurationModule.Scheduler.WebSiteProductsSyncJob_DisplayName, nameof(ProductsJob)))
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity(new TriggerKey(ConfigurationModule.Scheduler.WebSiteProductsSyncJob_TriggerName, nameof(ProductsJob)))
                .StartNow()
                .WithSimpleSchedule(builder =>
                {
                    builder.WithIntervalInSeconds(ConfigurationModule.Scheduler.WebSiteProductsSyncJob_ExecutionTime)
                        .RepeatForever();
                })
                .Build();


            var scheduler = await new StdSchedulerFactory().GetScheduler();
            await scheduler.ScheduleJob(jobDetails, trigger);

            await scheduler.Start();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                    .AddLogging()
                    .AddScoped<IProductService, ProductService>()
                    .BuildServiceProvider();
        }
    }
}
