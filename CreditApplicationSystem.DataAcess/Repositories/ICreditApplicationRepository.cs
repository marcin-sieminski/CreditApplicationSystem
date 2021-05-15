using CreditApplicationSystem.DataAccess.Entities;
using System.Collections.Generic;

namespace CreditApplicationSystem.DataAccess.Repositories
{
    public interface ICreditApplicationRepository
    {
        IEnumerable<CreditApplication> GetAllCreditApplications { get; }
        CreditApplication GetCreditApplicationById(int id);
        int GetActiveApplicationsNumber { get; }
    }
}
