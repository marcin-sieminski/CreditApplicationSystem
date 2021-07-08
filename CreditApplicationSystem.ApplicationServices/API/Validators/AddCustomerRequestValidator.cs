using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using FluentValidation;

namespace CreditApplicationSystem.ApplicationServices.API.Validators
{
    public class AddCustomerRequestValidator : AbstractValidator<AddCustomerRequest>
    {
        public AddCustomerRequestValidator()
        {
            RuleFor(x => x.CustomerFirstName).Length(3, 200);
            RuleFor(x => x.CustomerLastName).Length(3, 200);
        }
    }
}