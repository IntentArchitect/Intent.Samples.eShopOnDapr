using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application
{

    public class BasketData
    {
        public BasketData()
        {
        }

        public static BasketData Create(
            BasketDataItem items)
        {
            return new BasketData
            {
                Items = items,
            };
        }

        public BasketDataItem Items { get; set; }

    }
}