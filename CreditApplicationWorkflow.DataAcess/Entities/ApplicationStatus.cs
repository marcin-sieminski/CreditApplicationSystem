using System.ComponentModel.DataAnnotations;

namespace CreditApplicationWorkflow.DataAccess.Entities
{
    public class ApplicationStatus : EntityBase
    {
        [Required] public string ApplicationStatusName { get; set; }
    }
}
