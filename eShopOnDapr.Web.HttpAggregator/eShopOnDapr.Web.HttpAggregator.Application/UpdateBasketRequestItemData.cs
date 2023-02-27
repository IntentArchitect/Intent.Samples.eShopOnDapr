using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application
{

    public class UpdateBasketRequestItemData
    {
        public UpdateBasketRequestItemData()
        {
        }

        public static UpdateBasketRequestItemData Create(
            int productId,
            int quantity)
        {
            return new UpdateBasketRequestItemData
            {
                ProductId = productId,
                Quantity = quantity,
            };
        }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

    }
}