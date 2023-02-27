using System.Threading;
using System.Threading.Tasks;
using Dapr;
using EShopOnDapr.Ordering.Application;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.PubSub.DaprEventHandlerController", Version = "1.0")]

namespace EShopOnDapr.Ordering.Api.Controllers
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
        [Topic(UserCheckoutAcceptedIntegrationEvent.PubsubName, UserCheckoutAcceptedIntegrationEvent.TopicName)]
        public async Task HandleUserCheckoutAcceptedIntegrationEvent(UserCheckoutAcceptedIntegrationEvent @event, CancellationToken cancellationToken)
        {
            await _mediatr.Send(@event, cancellationToken);
        }
    }
}