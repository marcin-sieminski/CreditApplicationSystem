using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.ApplicationServices.API.Domain.Models;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.CQRS.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class GetCreditApplicationByIdHandler : IRequestHandler<GetCreditApplicationByIdRequest, GetCreditApplicationByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetCreditApplicationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetCreditApplicationByIdResponse> Handle(GetCreditApplicationByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCreditApplicationByIdQuery();
            var creditApplication = await _queryExecutor.Execute(query);

            var mappedCreditApplication = _mapper.Map<CreditApplication>(creditApplication);
            var response = new GetCreditApplicationByIdResponse()
            {
                Data = mappedCreditApplication
            };

            return response;
        }
    }
}