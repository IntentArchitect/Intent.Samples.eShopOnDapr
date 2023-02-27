using Dapr.Client;
using EShopOnDapr.Ordering.Application.NewServiceProxy;
using EShopOnDapr.Ordering.Infrastructure.HttpClients;
using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.DaprConfiguration", Version = "1.0")]

namespace EShopOnDapr.Ordering.Api.Configuration
{
    public static class DaprConfiguration
    {
        public static void AddDaprServices(this IServiceCollection services)
        {
            services.AddSingleton<INewServiceProxyClient, NewServiceProxyHttpClient>(_ => new NewServiceProxyHttpClient(DaprClient.CreateInvokeHttpClient("e-shop-on-dapr-basket")));
        }
    }
}