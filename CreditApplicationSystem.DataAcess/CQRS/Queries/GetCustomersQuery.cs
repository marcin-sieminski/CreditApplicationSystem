using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Queries
{
    public class GetCustomersQuery : QueryBase<List<Customer>>
    {
        public override Task<List<Customer>> Execute(CreditApplicationWorkflowDbContext context)
        {
            return context.Customers
                .ToListAsync();
        }
    }
}