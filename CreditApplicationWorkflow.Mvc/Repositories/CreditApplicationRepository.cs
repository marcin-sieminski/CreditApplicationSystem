using CreditApplicationWorkflow.DataAccess;
using CreditApplicationWorkflow.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CreditApplicationWorkflow.Mvc.Repositories
{
    public class CreditApplicationRepository : ICreditApplicationRepository
    {
        private readonly CreditApplicationWorkflowDbContext _creditApplicationWorkflowDbContext;

        public CreditApplicationRepository(CreditApplicationWorkflowDbContext creditApplicationWorkflowDbContext)
        {
            _creditApplicationWorkflowDbContext = creditApplicationWorkflowDbContext;
        }

        public IEnumerable<CreditApplication> GetAllCreditApplications { get => _creditApplicationWorkflowDbContext.CreditApplications
            .Include(x => x.Customer)
            .Include(x => x.ApplicationStatus)
            .Include(x => x.Employee)
            .Include(x => x.ProductType); }

        public CreditApplication GetCreditApplicationById(int id)
        {
            var creditApplication = _creditApplicationWorkflowDbContext.CreditApplications.Where(c => c.Id == id)
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.ApplicationStatus)
                .Include(x => x.ProductType)
                .FirstOrDefault(c => c.Id == id);
            return creditApplication;
        }

        public int GetActiveApplicationsNumber { get => _creditApplicationWorkflowDbContext.CreditApplications.Count(x => x.IsActive == true); }
    }
}
