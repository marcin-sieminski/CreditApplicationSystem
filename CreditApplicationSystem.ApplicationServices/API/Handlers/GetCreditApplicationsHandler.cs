using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.DataAccess.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class GetCreditApplicationsHandler : IRequestHandler<GetCreditApplicationsRequest, GetCreditApplicationsResponse>
    {
        private readonly IRepository<DataAccess.Entities.CreditApplication> _creditApplicationRepository;

        public GetCreditApplicationsHandler(IRepository<DataAccess.Entities.CreditApplication> creditApplicationRepository)
        {
            _creditApplicationRepository = creditApplicationRepository;
        }

        public Task<GetCreditApplicationsResponse> Handle(GetCreditApplicationsRequest request, CancellationToken cancellationToken)
        {
            var creditApplications = _creditApplicationRepository.GetAll();

            var domainCreditApplications = creditApplications.Select(x => new Domain.Models.CreditApplication()
            {
                Id = x.Id,
                CustomerName = x.Customer.CustomerFirstName + " " + x.Customer.CustomerLastName,
                DateOfSubmission = x.DateOfSubmission,
                AmountRequested = x.AmountRequested
            });

            var response = new GetCreditApplicationsResponse()
            {
                Data = domainCreditApplications.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
