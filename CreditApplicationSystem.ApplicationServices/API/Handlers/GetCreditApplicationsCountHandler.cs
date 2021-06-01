using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.CQRS.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class GetCreditApplicationsCountHandler : IRequestHandler<GetCreditApplicationsCountRequest, GetCreditApplicationsCountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetCreditApplicationsCountHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetCreditApplicationsCountResponse> Handle(GetCreditApplicationsCountRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCreditApplicationsCountQuery();
            var creditApplicationsCount = await _queryExecutor.Execute(query);
            
            var response = new GetCreditApplicationsCountResponse()
            {
                Data = creditApplicationsCount
            };

            return response;
        }
    }
}