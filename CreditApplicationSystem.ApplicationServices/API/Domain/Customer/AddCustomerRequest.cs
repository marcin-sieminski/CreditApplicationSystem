using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Customer
{
    public class AddCustomerRequest : IRequest<AddCustomerResponse>
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}