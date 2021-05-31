using System.Collections.Generic;

namespace CreditApplicationWorkflow.Mvc.ViewModels
{
    public class CreditApplicationListViewModel
    {
        public List<CreditApplicationSystem.ApplicationServices.API.Domain.Models.CreditApplication> CreditApplications { get; set; }
    }
}
