using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Queries
{
    public class GetCustomerQuery : QueryBase<Customer>
    {
        public int Id { get; set; }

        public override async Task<Customer> Execute(CreditApplicationWorkflowDbContext context)
        {
            return await context.Customers
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}