using System.ComponentModel.DataAnnotations;

namespace CreditApplicationWorkflow.DataAccess.Entities
{
    public class Customer : EntityBase
    {
        [Required]
        [MaxLength(500)]
        public string CustomerName { get; set; }
    }
}
