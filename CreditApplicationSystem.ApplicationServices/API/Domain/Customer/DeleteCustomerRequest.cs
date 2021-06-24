using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Customer
{
    public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
    {
        public int Id { get; set; }
    }
}