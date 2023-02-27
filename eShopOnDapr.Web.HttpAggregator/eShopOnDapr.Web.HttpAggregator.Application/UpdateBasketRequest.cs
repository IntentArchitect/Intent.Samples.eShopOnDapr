using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application
{

    public class UpdateBasketRequest
    {
        public UpdateBasketRequest()
        {
        }

        public static UpdateBasketRequest Create(
            UpdateBasketRequestItemData items)
        {
            return new UpdateBasketRequest
            {
                Items = items,
            };
        }

        public UpdateBasketRequestItemData Items { get; set; }

    }
}