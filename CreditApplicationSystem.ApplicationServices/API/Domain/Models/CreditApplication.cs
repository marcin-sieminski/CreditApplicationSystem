using System;
using System.ComponentModel.DataAnnotations;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Models
{
    public class CreditApplication
    {
        public int Id { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string ProductTypeName { get; set; }
        public string Currency { get; set; }
        public decimal AmountRequested { get; set; }
        public decimal AmountGranted { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime DateOfLastStatusChange { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
