using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Queries
{
    public class GetCreditApplicationsCountQuery : QueryBase<int>
    {
        public override Task<int> Execute(CreditApplicationWorkflowDbContext context)
        {
            return context.CreditApplications.CountAsync();
        }

    }
}