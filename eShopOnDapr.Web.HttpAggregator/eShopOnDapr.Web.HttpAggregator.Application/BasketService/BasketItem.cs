using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application.BasketService
{
    public class BasketItem
    {
        public static BasketItem Create(
            int productId,
            string productName,
            decimal unitPrice,
            int quantity,
            string pictureFileName)
        {
            return new BasketItem
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
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureFileName { get; set; }
    }
}