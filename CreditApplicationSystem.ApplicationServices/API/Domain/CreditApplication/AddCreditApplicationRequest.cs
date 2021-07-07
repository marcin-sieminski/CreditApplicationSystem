using MediatR;
using System;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication
{
    public class AddCreditApplicationRequest : IRequest<AddCreditApplicationResponse>
    {
        public DateTime DateOfSubmission { get; set; }
        public int CustomerId { get; set; }
        public int ProductTypeId { get; set; }
        public decimal AmountRequested { get; set; }
        public decimal AmountGranted { get; set; }
        public int ApplicationStatusId { get; set; }
        public DateTime DateOfLastStatusChange { get; set; }
        public int EmployeeId { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}