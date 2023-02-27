using System;
using System.Collections.Generic;
using EShopOnDapr.Ordering.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace EShopOnDapr.Ordering.Application.DoPub
{
    public class DoPub : IRequest, ICommand
    {
    }
}