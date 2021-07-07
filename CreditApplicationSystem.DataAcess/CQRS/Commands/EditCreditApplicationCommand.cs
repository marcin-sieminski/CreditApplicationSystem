using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Commands
{
    public class EditCreditApplicationCommand : CommandBase<CreditApplication, CreditApplication>
    {
        public override async Task<CreditApplication> Execute(CreditApplicationWorkflowDbContext context)
        {
            var creditApplication = await context.CreditApplications.FirstOrDefaultAsync(c => c.Id == Parameter.Id);

            creditApplication.DateOfSubmission = Parameter.DateOfSubmission;
            creditApplication.CustomerId = Parameter.CustomerId;
            creditApplication.ProductTypeId = Parameter.ProductTypeId;
            creditApplication.AmountRequested = Parameter.AmountRequested;
            creditApplication.AmountGranted = Parameter.AmountGranted;
            creditApplication.DateOfLastStatusChange = Parameter.DateOfLastStatusChange;
            creditApplication.EmployeeId = Parameter.EmployeeId;
            creditApplication.Notes = Parameter.Notes;
            creditApplication.IsActive = Parameter.IsActive;

            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}