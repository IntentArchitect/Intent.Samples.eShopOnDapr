using System;
using System.Collections.Generic;
using EShopOnDapr.Basket.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace EShopOnDapr.Basket.Application.DeleteBasket
{
    public class DeleteBasketCommand : IRequest, ICommand
    {
    }
}