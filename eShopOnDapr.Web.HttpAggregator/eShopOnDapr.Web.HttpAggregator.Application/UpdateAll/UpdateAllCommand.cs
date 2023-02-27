using System;
using System.Collections.Generic;
using EShopOnDapr.Web.HttpAggregator.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application.UpdateAll
{
    public class UpdateAllCommand : IRequest<BasketData>, ICommand
    {
        public UpdateBasketRequest Data { get; set; }

        public string Authorization { get; set; }

    }
}