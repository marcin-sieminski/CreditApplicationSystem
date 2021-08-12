using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Users
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}