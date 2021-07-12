using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Users
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
        public string Username { get; set; }
    }
}