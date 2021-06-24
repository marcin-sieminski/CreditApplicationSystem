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
    public class EditCustomerHandler : IRequestHandler<EditCustomerRequest, EditCustomerResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public EditCustomerHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<EditCustomerResponse> Handle(EditCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            var command = new EditCustomerCommand() { Parameter = customer };
            var customerFromDb = await _commandExecutor.Execute(command);
            return new EditCustomerResponse()
            {
                Data = _mapper
                    .Map<CreditApplicationSystem.ApplicationServices.API.Domain.Models.Customer>(customerFromDb)
            };
        }
    }
}