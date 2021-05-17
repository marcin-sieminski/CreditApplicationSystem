using System;
using System.Collections.Generic;
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
        [Required]
        public Customer Customer { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        [Required]
        public decimal AmountRequested { get; set; }
        public decimal AmountGranted { get; set; }
        [Required]
        public int ApplicationStatusId { get; set; }
        [Required] public ApplicationStatus ApplicationStatus { get; set; }
        [Required]
        public DateTime DateOfLastStatusChange { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [MaxLength(3000)]
        public string Notes { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
