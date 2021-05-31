using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.DataAccess;
using CreditApplicationSystem.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class GetCreditApplicationsHandler : IRequestHandler<GetCreditApplicationsRequest, GetCreditApplicationsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetCreditApplicationsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetCreditApplicationsResponse> Handle(GetCreditApplicationsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCreditApplicationsQuery();
            var creditApplications = await _queryExecutor.Execute(query);
            
            var mappedCreditApplications = _mapper.Map<List<Domain.Models.CreditApplication>>(creditApplications);

            var response = new GetCreditApplicationsResponse()
            {
                Data = mappedCreditApplications
            };

            return response;
        }
    }
}
