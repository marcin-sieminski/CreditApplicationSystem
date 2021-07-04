using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication
{
    public class DeleteCreditApplicationRequest : IRequest<DeleteCreditApplicationResponse>
    {
        public int Id { get; set; }
    }
}