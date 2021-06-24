using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Commands
{
    public class DeleteCustomerCommand : CommandBase<Customer, int>
    {
        public override async Task<int> Execute(CreditApplicationWorkflowDbContext context)
        {
            var customer = await context.Customers.SingleOrDefaultAsync(c => c.Id == Parameter.Id);
            context.Remove(customer);
            
            return await context.SaveChangesAsync();
        }
    }
}