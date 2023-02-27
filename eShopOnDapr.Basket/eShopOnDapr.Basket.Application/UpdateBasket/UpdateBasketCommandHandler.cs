using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace EShopOnDapr.Basket.Application.UpdateBasket
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, CustomerBasket>
    {
        [IntentManaged(Mode.Ignore)]
        public UpdateBasketCommandHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<CustomerBasket> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}