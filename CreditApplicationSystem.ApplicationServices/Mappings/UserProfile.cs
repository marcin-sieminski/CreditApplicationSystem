using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace CreditApplicationSystem.ApplicationServices.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<IdentityUser, API.Domain.Models.User>();
        }
    }
}
