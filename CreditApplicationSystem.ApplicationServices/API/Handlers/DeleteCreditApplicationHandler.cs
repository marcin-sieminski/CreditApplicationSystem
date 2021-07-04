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
    public class DeleteCreditApplicationHandler : IRequestHandler<DeleteCreditApplicationRequest, DeleteCreditApplicationResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public DeleteCreditApplicationHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<DeleteCreditApplicationResponse> Handle(DeleteCreditApplicationRequest request, CancellationToken cancellationToken)
        {
            var creditApplication = _mapper.Map<CreditApplication>(request);
            var command = new DeleteCreditApplicationCommand { Parameter = creditApplication };
            var confirmation = await _commandExecutor.Execute(command);

            return new DeleteCreditApplicationResponse
            {
                Data = confirmation
            };
        }
    }
}