using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Users
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}