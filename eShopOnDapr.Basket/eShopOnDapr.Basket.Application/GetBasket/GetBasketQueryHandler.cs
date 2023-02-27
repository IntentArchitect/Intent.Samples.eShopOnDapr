using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace EShopOnDapr.Basket.Application.GetBasket
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, CustomerBasket>
    {
        [IntentManaged(Mode.Ignore)]
        public GetBasketQueryHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<CustomerBasket> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Your implementation here...");
        }
    }
}