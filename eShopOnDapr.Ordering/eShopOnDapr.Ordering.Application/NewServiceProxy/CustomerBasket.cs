using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace EShopOnDapr.Ordering.Application.NewServiceProxy
{
    public class CustomerBasket
    {
        public static CustomerBasket Create(
            string buyerId,
            List<BasketItem> items)
        {
            return new CustomerBasket
            {
                BuyerId = buyerId,
                Items = items,
            };
        }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}