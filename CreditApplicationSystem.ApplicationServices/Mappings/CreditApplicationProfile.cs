using AutoMapper;

namespace CreditApplicationSystem.ApplicationServices.Mappings
{
    public class CreditApplicationProfile : Profile
    {
        public CreditApplicationProfile()
        {
            CreateMap<DataAccess.Entities.CreditApplication, API.Domain.Models.CreditApplication>();
        }
    }
}
