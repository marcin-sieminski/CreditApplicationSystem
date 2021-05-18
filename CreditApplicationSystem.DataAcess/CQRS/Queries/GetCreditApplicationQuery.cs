using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Queries
{
    public class GetCreditApplicationQuery : QueryBase<CreditApplication>
    {
        public int Id { get; set; }

        public override async Task<CreditApplication> Execute(CreditApplicationWorkflowDbContext context)
        {
            var creditApplication = await context.CreditApplications
                .Include(x => x.Customer)
                .Include(x => x.ApplicationStatus)
                .Include(x => x.Employee)
                .Include(x => x.ProductType)
                .FirstOrDefaultAsync(x => x.Id == Id);
            return creditApplication;
        }
    }
}
