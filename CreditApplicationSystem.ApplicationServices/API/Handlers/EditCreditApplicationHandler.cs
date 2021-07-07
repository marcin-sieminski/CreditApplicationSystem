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
    public class EditCreditApplicationHandler : IRequestHandler<EditCreditApplicationRequest, EditCreditApplicationResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public EditCreditApplicationHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<EditCreditApplicationResponse> Handle(EditCreditApplicationRequest request, CancellationToken cancellationToken)
        {
            var creditApplication = _mapper.Map<CreditApplication>(request);
            var command = new EditCreditApplicationCommand() { Parameter = creditApplication };
            var creditApplicationFromDb = await _commandExecutor.Execute(command);
            return new EditCreditApplicationResponse()
            {
                Data = _mapper
                    .Map<CreditApplicationSystem.ApplicationServices.API.Domain.Models.CreditApplication>(creditApplicationFromDb)
            };
        }
    }
}