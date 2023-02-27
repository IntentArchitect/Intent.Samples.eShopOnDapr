using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application
{

    public class BasketDataItem
    {
        public BasketDataItem()
        {
        }

        public static BasketDataItem Create(
            int productId,
            string productName,
            string unitPrice,
            int quantity,
            string pictureFileName)
        {
            return new BasketDataItem
            {
                ProductId = productId,
                ProductName = productName,
                UnitPrice = unitPrice,
                Quantity = quantity,
                PictureFileName = pictureFileName,
            };
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string UnitPrice { get; set; }

        public int Quantity { get; set; }

        public string PictureFileName { get; set; }

    }
}