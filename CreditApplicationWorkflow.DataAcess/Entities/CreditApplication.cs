using System;

namespace CreditApplicationWorkflow.DataAccess.Entities
{
    public class CreditApplication
    {
        public int Id { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public decimal AmountRequested { get; set; }
        public decimal AmountGranted { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime DateOfLastStatusChange { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
