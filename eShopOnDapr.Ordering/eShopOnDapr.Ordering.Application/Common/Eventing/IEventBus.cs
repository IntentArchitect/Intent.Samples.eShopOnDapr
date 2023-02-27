using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.PubSub.EventBusInterface", Version = "1.0")]

namespace EShopOnDapr.Ordering.Application.Common.Eventing
{
    public interface IEventBus
    {

        void Publish<T>(T message)
            where T : IEvent;
        Task FlushAllAsync(CancellationToken cancellationToken = default);
    }
}