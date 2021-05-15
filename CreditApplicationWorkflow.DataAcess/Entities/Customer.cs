using System.ComponentModel.DataAnnotations;

namespace CreditApplicationWorkflow.DataAccess.Entities
{
    public class Customer : EntityBase
    {
        [Required]
        [MaxLength(500)]
        public string CustomerFirstName { get; set; }

        [Required]
        [MaxLength(500)]
        public string CustomerLastName { get; set; }
    }
}
