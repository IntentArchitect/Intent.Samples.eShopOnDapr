using System;
using System.Threading;
using System.Threading.Tasks;
using EShopOnDapr.Ordering.Application.Common.Eventing;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace EShopOnDapr.Ordering.Application.DoPub
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DoPubHandler : IRequestHandler<DoPub>
    {
        private readonly IEventBus _eventBus;

        [IntentManaged(Mode.Ignore)]
        public DoPubHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(DoPub request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new OrderStatusChangedToSubmittedIntegrationEvent
            {
                BuyerId = Guid.NewGuid().ToString(),
                OrderId = Guid.NewGuid(),
                OrderStatus = "Something"
            });

            return Unit.Value;
        }
    }
}