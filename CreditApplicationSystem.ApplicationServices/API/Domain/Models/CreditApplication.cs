using System;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Models
{
    public class CreditApplication
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public decimal AmountRequested { get; set; }
        public DateTime DateOfSubmission { get; set; }
    }
}
