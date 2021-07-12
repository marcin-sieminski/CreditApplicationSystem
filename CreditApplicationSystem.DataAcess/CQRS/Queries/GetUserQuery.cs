using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<IdentityUser>
    {
        public string Username { get; set; }

        public override Task<IdentityUser> Execute(CreditApplicationWorkflowDbContext context)
        {
            return context.Users.FirstOrDefaultAsync(x => x.UserName == Username);
        }
    }
}