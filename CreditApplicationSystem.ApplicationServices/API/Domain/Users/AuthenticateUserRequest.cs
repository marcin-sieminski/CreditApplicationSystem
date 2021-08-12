using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Users
{
    public class AuthenticateUserRequest : IRequest<AuthenticateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}