using System.ComponentModel.DataAnnotations;

namespace CreditApplicationWorkflow.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
