using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.ServiceContract", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application.BasketService
{
    public interface IBasketClient : IDisposable
    {
        Task<CustomerBasket> GetBasketAsync(CancellationToken cancellationToken = default);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket value, CancellationToken cancellationToken = default);
        Task CheckoutAsync(BasketCheckout basketCheckout, string requestId, CancellationToken cancellationToken = default);
        Task DeleteBasketAsync(CancellationToken cancellationToken = default);
    }
}