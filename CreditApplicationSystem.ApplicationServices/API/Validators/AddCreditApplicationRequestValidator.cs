using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;
using FluentValidation;

namespace CreditApplicationSystem.ApplicationServices.API.Validators
{
    public class AddCreditApplicationRequestValidator : AbstractValidator<AddCreditApplicationRequest>
    {
        public AddCreditApplicationRequestValidator()
        {
            RuleFor(x => x.AmountRequested).GreaterThan(0);
        }
    }
}