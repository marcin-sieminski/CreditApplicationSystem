using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication
{
    public class GetCreditApplicationByIdRequest : IRequest<GetCreditApplicationByIdResponse>
    {
        public int Id { get; set; }
    }
}