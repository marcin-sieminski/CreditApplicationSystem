using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<IdentityUser>>
    {
        public string Username { get; set; }

        public override Task<List<IdentityUser>> Execute(CreditApplicationWorkflowDbContext context)
        {
            return context.Users.ToListAsync();
        }
    }
}