using System.ComponentModel.DataAnnotations;

namespace CreditApplicationWorkflow.DataAccess.Entities
{
    public class Department : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string DepartmentName { get; set; }
    }
}
