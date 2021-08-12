using CreditApplicationSystem.ApplicationServices.API.Domain.Users;
using FluentValidation;

namespace CreditApplicationSystem.ApplicationServices.API.Validators
{
    public class AuthenticateUserValidator : AbstractValidator<ValidateUserRequest>
    {
        public AuthenticateUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}