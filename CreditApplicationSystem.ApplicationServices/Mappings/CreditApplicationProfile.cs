using AutoMapper;

namespace CreditApplicationSystem.ApplicationServices.Mappings
{
    public class CreditApplicationProfile : Profile
    {
        public CreditApplicationProfile()
        {
            CreateMap<DataAccess.Entities.CreditApplication, API.Domain.Models.CreditApplication>()
                .ForMember(x => x.CustomerFirstName, y => y.MapFrom(z => z.Customer.CustomerFirstName))
                .ForMember(x => x.CustomerLastName, y => y.MapFrom(z => z.Customer.CustomerLastName));
        }
    }
}
