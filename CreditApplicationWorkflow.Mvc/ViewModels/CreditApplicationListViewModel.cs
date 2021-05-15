using CreditApplicationSystem.DataAccess.Entities;
using System.Collections.Generic;

namespace CreditApplicationWorkflow.Mvc.ViewModels
{
    public class CreditApplicationListViewModel
    {
        public IEnumerable<CreditApplication> CreditApplications { get; set; }
    }
}
