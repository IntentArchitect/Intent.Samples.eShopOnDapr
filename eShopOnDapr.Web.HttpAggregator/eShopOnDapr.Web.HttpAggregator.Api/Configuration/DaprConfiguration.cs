using Dapr.Client;
using EShopOnDapr.Web.HttpAggregator.Application.BasketService;
using EShopOnDapr.Web.HttpAggregator.Infrastructure.HttpClients;
using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.DaprConfiguration", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Api.Configuration
{
    public static class DaprConfiguration
    {
        public static void AddDaprServices(this IServiceCollection services)
        {
            services.AddSingleton<IBasketClient, BasketServiceHttpClient>(_ => new BasketServiceHttpClient(DaprClient.CreateInvokeHttpClient("e-shop-on-dapr-basket")));
        }
    }
}