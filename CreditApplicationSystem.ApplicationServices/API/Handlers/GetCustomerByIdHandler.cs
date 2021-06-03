using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using CreditApplicationSystem.ApplicationServices.API.Domain.Models;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.CQRS.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;


        public GetCustomerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCustomerQuery()
            {
                Id = request.Id
            };
            var customer = await _queryExecutor.Execute(query);

            var mappedCustomer = _mapper.Map<Customer>(customer);
            var response = new GetCustomerByIdResponse()
            {
                Data = mappedCustomer
            };

            return response;        }
    }
}