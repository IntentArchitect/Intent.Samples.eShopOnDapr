using System.Threading;
using System.Threading.Tasks;
using EShopOnDapr.Ordering.Application.Common.Eventing;
using EShopOnDapr.Ordering.Application.NewServiceProxy;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.EventBusPublishBehaviour", Version = "1.0")]

namespace EShopOnDapr.Ordering.Application.Common.Behaviours
{
    public class EventBusPublishBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEventBus _eventBus;

        public EventBusPublishBehaviour(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            await _eventBus.FlushAllAsync(cancellationToken);

            return response;
        }
    }
}