using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.EventHandler", Version = "1.0")]

namespace EShopOnDapr.Basket.Application.OrderStatusChangedToSubmittedIntegration
{
    [IntentManaged(Mode.Merge, Body = Mode.Fully)]
    public class OrderStatusChangedToSubmittedIntegrationEventHandler : IRequestHandler<OrderStatusChangedToSubmittedIntegrationEvent>
    {
        [IntentManaged(Mode.Ignore)]
        public OrderStatusChangedToSubmittedIntegrationEventHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(OrderStatusChangedToSubmittedIntegrationEvent @event, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}