using System.Threading;
using System.Threading.Tasks;
using Dapr;
using EShopOnDapr.Basket.Application;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.PubSub.DaprEventHandlerController", Version = "1.0")]

namespace EShopOnDapr.Basket.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class DaprEventHandlerController : ControllerBase
    {
        private readonly ISender _mediatr;

        public DaprEventHandlerController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        [Topic(OrderStatusChangedToSubmittedIntegrationEvent.PubsubName, OrderStatusChangedToSubmittedIntegrationEvent.TopicName)]
        public async Task HandleOrderStatusChangedToSubmittedIntegrationEvent(OrderStatusChangedToSubmittedIntegrationEvent @event, CancellationToken cancellationToken)
        {
            await _mediatr.Send(@event, cancellationToken);
        }
    }
}