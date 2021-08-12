using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Users
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}