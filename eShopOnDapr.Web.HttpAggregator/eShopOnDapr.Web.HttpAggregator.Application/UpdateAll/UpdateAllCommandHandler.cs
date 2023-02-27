using System;
using System.Threading;
using System.Threading.Tasks;
using EShopOnDapr.Web.HttpAggregator.Application.BasketService;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application.UpdateAll
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateAllCommandHandler : IRequestHandler<UpdateAllCommand, BasketData>
    {
        private readonly IBasketClient _basketClient;

        [IntentManaged(Mode.Ignore)]
        public UpdateAllCommandHandler(IBasketClient basketClient)
        {
            _basketClient = basketClient;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<BasketData> Handle(UpdateAllCommand request, CancellationToken cancellationToken)
        {
            var result = await _basketClient.GetBasketAsync(cancellationToken);

            return null;
        }
    }
}