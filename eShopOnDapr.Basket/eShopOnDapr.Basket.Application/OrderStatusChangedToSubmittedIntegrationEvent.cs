using System;
using EShopOnDapr.Basket.Application.Common.Eventing;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.Event", Version = "1.0")]

namespace EShopOnDapr.Basket.Application
{
    public class OrderStatusChangedToSubmittedIntegrationEvent : IEvent
    {
        public const string PubsubName = "pubsub";
        public const string TopicName = nameof(OrderStatusChangedToSubmittedIntegrationEvent);

        public Guid? OrderId { get; set; }

        public string? OrderStatus { get; set; }

        public string? BuyerId { get; set; }

        string IEvent.PubsubName => PubsubName;

        string IEvent.TopicName => TopicName;
    }
}