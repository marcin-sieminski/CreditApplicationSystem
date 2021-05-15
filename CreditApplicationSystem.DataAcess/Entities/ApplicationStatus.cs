using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreditApplicationSystem.DataAccess.Entities
{
    public class ApplicationStatus : EntityBase
    {
        [Required] public string ApplicationStatusName { get; set; }

        public List<CreditApplication> CreditApplications { get; set; }
    }
}
