using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application.BasketService
{
    public class BasketCheckout
    {
        public static BasketCheckout Create(
            string userEmail,
            string city,
            string street,
            string state,
            string country,
            string cardNumber,
            string cardHolderName,
            DateTime cardExpiration,
            string cardSecurityCode)
        {
            return new BasketCheckout
            {
                UserEmail = userEmail,
                City = city,
                Street = street,
                State = state,
                Country = country,
                CardNumber = cardNumber,
                CardHolderName = cardHolderName,
                CardExpiration = cardExpiration,
                CardSecurityCode = cardSecurityCode,
            };
        }
        public string UserEmail { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime CardExpiration { get; set; }
        public string CardSecurityCode { get; set; }
    }
}