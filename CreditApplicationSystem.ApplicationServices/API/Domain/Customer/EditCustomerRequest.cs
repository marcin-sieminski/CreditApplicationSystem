using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Customer
{
    public class EditCustomerRequest : IRequest<EditCustomerResponse>
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}