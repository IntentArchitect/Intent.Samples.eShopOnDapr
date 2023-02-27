using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace EShopOnDapr.Basket.Application.Checkout
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CheckoutCommandValidator : AbstractValidator<CheckoutCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CheckoutCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.BasketCheckout)
                .NotNull();

            RuleFor(v => v.RequestId)
                .NotNull();

        }
    }
}