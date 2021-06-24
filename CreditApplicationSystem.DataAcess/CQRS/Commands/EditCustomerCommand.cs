using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Commands
{
    public class EditCustomerCommand : CommandBase<Customer, Customer>
    {
        public override async Task<Customer> Execute(CreditApplicationWorkflowDbContext context)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == Parameter.Id);
            customer.CustomerFirstName = Parameter.CustomerFirstName;
            customer.CustomerLastName = Parameter.CustomerLastName;
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}