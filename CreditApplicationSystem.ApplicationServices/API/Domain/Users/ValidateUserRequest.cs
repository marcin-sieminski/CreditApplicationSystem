using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Users
{
    public class ValidateUserRequest : IRequest<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}