using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Customer
{
    public class GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
    {
        public int Id { get; set; }
    }
}