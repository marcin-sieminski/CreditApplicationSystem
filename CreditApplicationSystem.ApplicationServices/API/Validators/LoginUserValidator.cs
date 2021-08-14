using CreditApplicationSystem.ApplicationServices.API.Domain.Users;
using FluentValidation;

namespace CreditApplicationSystem.ApplicationServices.API.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}