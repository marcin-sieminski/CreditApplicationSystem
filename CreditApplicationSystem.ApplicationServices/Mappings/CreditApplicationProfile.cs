using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;

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

            CreateMap<DataAccess.Entities.CreditApplication, API.Domain.Models.CreditApplication>();

            CreateMap<AddCreditApplicationRequest, DataAccess.Entities.CreditApplication>()
                .ForMember(x => x.DateOfSubmission, y => y.MapFrom(z => z.DateOfSubmission))
                .ForMember(x => x.CustomerId, y => y.MapFrom(z => z.CustomerId))
                .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.ProductTypeId))
                .ForMember(x => x.Currency, y => y.MapFrom(z => z.Currency))
                .ForMember(x => x.AmountRequested, y => y.MapFrom(z => z.AmountRequested))
                .ForMember(x => x.AmountGranted, y => y.MapFrom(z => z.AmountGranted))
                .ForMember(x => x.ApplicationStatusId, y => y.MapFrom(z => z.ApplicationStatusId))
                .ForMember(x => x.DateOfLastStatusChange, y => y.MapFrom(z => z.DateOfLastStatusChange))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId))
                .ForMember(x => x.Notes, y => y.MapFrom(z => z.Notes))
                .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive));
            
            CreateMap<EditCreditApplicationRequest, DataAccess.Entities.CreditApplication>()
                .ForMember(x => x.DateOfSubmission, y => y.MapFrom(z => z.DateOfSubmission))
                .ForMember(x => x.CustomerId, y => y.MapFrom(z => z.CustomerId))
                .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.ProductTypeId))
                .ForMember(x => x.Currency, y =>y.MapFrom(z => z.Currency))
                .ForMember(x => x.AmountRequested, y => y.MapFrom(z => z.AmountRequested))
                .ForMember(x => x.AmountGranted, y => y.MapFrom(z => z.AmountGranted))
                .ForMember(x => x.ApplicationStatusId, y => y.MapFrom(z => z.ApplicationStatusId))
                .ForMember(x => x.DateOfLastStatusChange, y => y.MapFrom(z => z.DateOfLastStatusChange))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId))
                .ForMember(x => x.Notes, y => y.MapFrom(z => z.Notes))
                .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive));
        }
    }
}
