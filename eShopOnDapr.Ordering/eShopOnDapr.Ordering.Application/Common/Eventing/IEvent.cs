using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.PubSub.EventInterface", Version = "1.0")]

namespace EShopOnDapr.Ordering.Application.Common.Eventing
{
    public interface IEvent : IRequest
    {

        string PubsubName { get; }
        string TopicName { get; }
    }
}