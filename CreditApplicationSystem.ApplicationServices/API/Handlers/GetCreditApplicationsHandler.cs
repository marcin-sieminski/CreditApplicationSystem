using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.DataAccess.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class GetCreditApplicationsHandler : IRequestHandler<GetCreditApplicationsRequest, GetCreditApplicationsResponse>
    {
        private readonly IRepository<DataAccess.Entities.CreditApplication> _creditApplicationRepository;
        private readonly IMapper _mapper;

        public GetCreditApplicationsHandler(IRepository<DataAccess.Entities.CreditApplication> creditApplicationRepository, IMapper mapper)
        {
            _creditApplicationRepository = creditApplicationRepository;
            _mapper = mapper;
        }

        public Task<GetCreditApplicationsResponse> Handle(GetCreditApplicationsRequest request, CancellationToken cancellationToken)
        {
            var creditApplications = _creditApplicationRepository.GetAll();

            var mappedCreditApplications = _mapper.Map<List<Domain.Models.CreditApplication>>(creditApplications);

            var response = new GetCreditApplicationsResponse()
            {
                Data = mappedCreditApplications
            };
            return Task.FromResult(response);
        }
    }
}
