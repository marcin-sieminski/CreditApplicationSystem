using AutoMapper;

namespace CreditApplicationSystem.ApplicationServices.Mappings
{
    public class CreditApplicationProfile : Profile
    {
        public CreditApplicationProfile()
        {
            CreateMap<DataAccess.Entities.CreditApplication, API.Domain.Models.CreditApplication>()
                .ForMember(x => x.CustomerFirstName, y => y.MapFrom(z => z.Customer.CustomerFirstName))
                .ForMember(x => x.CustomerLastName, y => y.MapFrom(z => z.Customer.CustomerLastName))
                .ForMember(x => x.ProductTypeName, y => y.MapFrom(z => z.ProductType.ProductTypeName))
                .ForMember(x => x.ApplicationStatus, y => y.MapFrom(z => z.ApplicationStatus.ApplicationStatusName))
                .ForMember(x => x.EmployeeFirstName, y => y.MapFrom(z => z.Employee.FirstName))
                .ForMember(x => x.EmployeeLastName, y => y.MapFrom(z => z.Employee.LastName));

            CreateMap<DataAccess.Entities.Customer, API.Domain.Models.Customer>();
        }
    }
}
