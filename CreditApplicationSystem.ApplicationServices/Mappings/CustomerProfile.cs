using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using CreditApplicationSystem.DataAccess.Entities;

namespace CreditApplicationSystem.ApplicationServices.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, API.Domain.Models.Customer>();
            CreateMap<AddCustomerRequest, Customer>();
            CreateMap<EditCustomerRequest, Customer>();
        }
    }
}
