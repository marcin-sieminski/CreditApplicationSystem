using System.Collections.Generic;
using System.Linq;
using CreditApplicationWorkflow.DataAccess;
using CreditApplicationWorkflow.DataAccess.Entities;

namespace CreditApplicationWorkflow.Mvc.Repositories
{
    public class CreditApplicationRepository : ICreditApplicationRepository
    {
        private readonly CreditApplicationWorkflowDbContext _creditApplicationWorkflowDbContext;

        public CreditApplicationRepository(CreditApplicationWorkflowDbContext creditApplicationWorkflowDbContext)
        {
            _creditApplicationWorkflowDbContext = creditApplicationWorkflowDbContext;
        }

        public IEnumerable<CreditApplication> GetAllCreditApplications { get => _creditApplicationWorkflowDbContext.CreditApplications; }

        public CreditApplication GetCreditApplicationById(int id)
        {
            return _creditApplicationWorkflowDbContext.CreditApplications.FirstOrDefault(c => c.Id == id);
        }
    }
}
