using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<IdentityUser, IdentityUser>
    {
        public override Task<IdentityUser> Execute(CreditApplicationWorkflowDbContext context)
        {
            return Task.FromResult(Parameter);
        }
    }
}
