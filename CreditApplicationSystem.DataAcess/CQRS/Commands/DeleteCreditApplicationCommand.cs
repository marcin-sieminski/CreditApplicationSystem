using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Commands
{
    public class DeleteCreditApplicationCommand : CommandBase<CreditApplication, int>
    {
        public override async Task<int> Execute(CreditApplicationWorkflowDbContext context)
        {
            var creditApplication = await context.CreditApplications.SingleOrDefaultAsync(c => c.Id == Parameter.Id);
            context.Remove(creditApplication);
            
            return await context.SaveChangesAsync();
        }
    }
}