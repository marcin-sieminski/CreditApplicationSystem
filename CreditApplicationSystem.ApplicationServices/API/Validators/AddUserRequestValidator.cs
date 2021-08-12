using CreditApplicationSystem.ApplicationServices.API.Domain.Users;
using CreditApplicationSystem.DataAccess;
using FluentValidation;
using System.Linq;

namespace CreditApplicationSystem.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        private readonly CreditApplicationWorkflowDbContext _context;

        public AddUserRequestValidator(CreditApplicationWorkflowDbContext dbContext)
        {
            _context = dbContext;

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            
            RuleFor(x => x.Password).MinimumLength(6);
            
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password);
            
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = _context.Users.Any(u => u.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "Provided email is taken");
                }
            });
        }
    }
}