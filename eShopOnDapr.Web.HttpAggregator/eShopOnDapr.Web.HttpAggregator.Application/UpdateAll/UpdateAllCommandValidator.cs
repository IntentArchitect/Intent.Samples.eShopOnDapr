using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Application.UpdateAll
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateAllCommandValidator : AbstractValidator<UpdateAllCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateAllCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Data)
                .NotNull();

            RuleFor(v => v.Authorization)
                .NotNull();

        }
    }
}