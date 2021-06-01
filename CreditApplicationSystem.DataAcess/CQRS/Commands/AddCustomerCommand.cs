using CreditApplicationSystem.DataAccess.Entities;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Commands
{
    public class AddCustomerCommand : CommandBase<Customer, Customer>
    {
        public override async Task<Customer> Execute(CreditApplicationWorkflowDbContext context)
        {
            await context.Customers.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}