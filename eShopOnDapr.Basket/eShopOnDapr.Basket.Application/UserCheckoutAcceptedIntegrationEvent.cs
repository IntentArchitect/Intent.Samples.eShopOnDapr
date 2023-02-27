using EShopOnDapr.Basket.Application.Common.Eventing;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.Event", Version = "1.0")]

namespace EShopOnDapr.Basket.Application
{
    public class UserCheckoutAcceptedIntegrationEvent : IEvent
    {
        public const string PubsubName = "pubsub";
        public const string TopicName = nameof(UserCheckoutAcceptedIntegrationEvent);

        public string Email { get; set; }

        string IEvent.PubsubName => PubsubName;

        string IEvent.TopicName => TopicName;
    }
}