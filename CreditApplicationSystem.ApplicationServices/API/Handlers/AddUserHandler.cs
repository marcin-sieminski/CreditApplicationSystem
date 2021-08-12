using AutoMapper;
using CreditApplicationSystem.ApplicationServices.API.Domain.Users;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser { UserName = request.UserName, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            var command = new AddUserCommand() { Parameter = user };
            var userFromDb = await _commandExecutor.Execute(command);

            return new AddUserResponse()
            {
                Data = _mapper.Map<API.Domain.Models.User>(userFromDb)
            };
        }
    }
}