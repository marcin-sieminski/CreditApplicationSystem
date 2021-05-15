using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreditApplicationSystem.DataAccess.Entities
{
    public class Department : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
