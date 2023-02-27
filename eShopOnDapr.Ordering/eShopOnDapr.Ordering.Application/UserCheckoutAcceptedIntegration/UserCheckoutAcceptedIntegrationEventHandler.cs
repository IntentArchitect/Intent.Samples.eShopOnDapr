using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.PubSub.EventHandler", Version = "1.0")]

namespace EShopOnDapr.Ordering.Application.UserCheckoutAcceptedIntegration
{
    [IntentManaged(Mode.Merge, Body = Mode.Fully)]
    public class UserCheckoutAcceptedIntegrationEventHandler : IRequestHandler<UserCheckoutAcceptedIntegrationEvent>
    {
        [IntentManaged(Mode.Ignore)]
        public UserCheckoutAcceptedIntegrationEventHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(UserCheckoutAcceptedIntegrationEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}