using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace EShopOnDapr.Basket.Application.DeleteBasket
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand>
    {
        [IntentManaged(Mode.Ignore)]
        public DeleteBasketCommandHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Your implementation here...");
        }
    }
}