using System.ComponentModel.DataAnnotations;

namespace CreditApplicationWorkflow.DataAccess.Entities
{
    public class ProductType : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string ProductTypeName { get; set; }
    }
}
