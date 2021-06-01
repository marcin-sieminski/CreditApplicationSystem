using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.CQRS.Commands;
using CreditApplicationSystem.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, AddCustomerResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddCustomerHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddCustomerResponse> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            var command = new AddCustomerCommand() { Parameter = customer };
            var customerFromDb = await _commandExecutor.Execute(command);
            return new AddCustomerResponse()
            {
                Data = _mapper.Map<CreditApplicationSystem.ApplicationServices.API.Domain.Models.Customer>(
                    customerFromDb)
            };
        }
    }
}