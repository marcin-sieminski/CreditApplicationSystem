using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Queries
{
    public class GetCreditApplicationsQuery : QueryBase<List<CreditApplication>>
    {
        public override Task<List<CreditApplication>> Execute(CreditApplicationWorkflowDbContext context)
        {
            return context.CreditApplications
                .Include(x => x.Customer)
                .Include(x => x.ApplicationStatus)
                .Include(x => x.Employee)
                .Include(x => x.ProductType)
                .ToListAsync();
        }
    }
}
