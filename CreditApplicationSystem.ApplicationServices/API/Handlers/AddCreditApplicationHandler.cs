using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.CQRS.Commands;
using CreditApplicationSystem.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class AddCreditApplicationHandler : IRequestHandler<AddCreditApplicationRequest, AddCreditApplicationResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddCreditApplicationHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddCreditApplicationResponse> Handle(AddCreditApplicationRequest request, CancellationToken cancellationToken)
        {
            var creditApplication = _mapper.Map<CreditApplication>(request);
            var command = new AddCreditApplicationCommand() { Parameter = creditApplication };
            var creditApplicationFromDb = await _commandExecutor.Execute(command);

            return new AddCreditApplicationResponse()
            {
                Data = _mapper.Map<Domain.Models.CreditApplication>(creditApplicationFromDb)
            };
        }
    }
}