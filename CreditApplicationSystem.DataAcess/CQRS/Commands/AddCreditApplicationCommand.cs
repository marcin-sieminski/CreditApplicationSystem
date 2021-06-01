using CreditApplicationSystem.DataAccess.Entities;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Commands
{
    public class AddCreditApplicationCommand : CommandBase<CreditApplication, CreditApplication>
    {
        public override async Task<CreditApplication> Execute(CreditApplicationWorkflowDbContext context)
        {
            await context.CreditApplications.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}