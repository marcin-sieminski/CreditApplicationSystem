using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersRequest, GetCustomersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetCustomersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetCustomersResponse> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCustomersQuery();
            var customers = await _queryExecutor.Execute(query);
            var mappedCustomers = _mapper.Map<List<Domain.Models.Customer>>(customers);
            
            var response = new GetCustomersResponse()
            {
                Data = mappedCustomers
            };

            return response;
        }
    }
}