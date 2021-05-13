using System.Collections.Generic;
using System.Linq;
using CreditApplicationWorkflow.DataAccess;

namespace CreditApplicationWorkflow.Mvc.Models
{
    public class CreditApplicationRepository : ICreditApplicationRepository
    {
        private readonly AppDbContext _appDbContext;

        public CreditApplicationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<CreditApplication> GetAllCreditApplications { get => _appDbContext.CreditApplications; }

        public CreditApplication GetCreditApplicationById(int id)
        {
            return _appDbContext.CreditApplications.FirstOrDefault(c => c.Id == id);
        }
    }
}
