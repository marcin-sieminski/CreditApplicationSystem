using System.ComponentModel.DataAnnotations;

namespace CreditApplicationSystem.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
