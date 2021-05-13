using System.Collections.Generic;

namespace CreditApplicationWorkflow.Mvc.Models
{
    public interface ICreditApplicationRepository
    {
        IEnumerable<CreditApplication> GetAllCreditApplications { get; }
        CreditApplication GetCreditApplicationById(int id);
    }
}
