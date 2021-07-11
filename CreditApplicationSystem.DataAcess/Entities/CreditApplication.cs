using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditApplicationSystem.DataAccess.Entities
{
    public class CreditApplication : EntityBase
    {
        [Required]
        public DateTime DateOfSubmission { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public string Currency { get; set; }
        [Required]
        public decimal AmountRequested { get; set; }
        public decimal AmountGranted { get; set; }
        [Required]
        public int ApplicationStatusId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public DateTime DateOfLastStatusChange { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [MaxLength(3000)]
        public string Notes { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
