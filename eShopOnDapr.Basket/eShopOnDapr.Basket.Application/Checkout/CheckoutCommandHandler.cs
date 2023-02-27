using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace EShopOnDapr.Basket.Application.Checkout
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand>
    {
        [IntentManaged(Mode.Ignore)]
        public CheckoutCommandHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Your implementation here...");
        }
    }
}