using System.Collections.Generic;
using CreditApplicationWorkflow.DataAccess.Entities;

namespace CreditApplicationWorkflow.Mvc.Repositories
{
    public interface ICreditApplicationRepository
    {
        IEnumerable<CreditApplication> GetAllCreditApplications { get; }
        CreditApplication GetCreditApplicationById(int id);
    }
}
