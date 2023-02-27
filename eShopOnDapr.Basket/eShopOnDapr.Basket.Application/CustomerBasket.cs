using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace EShopOnDapr.Basket.Application
{

    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

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