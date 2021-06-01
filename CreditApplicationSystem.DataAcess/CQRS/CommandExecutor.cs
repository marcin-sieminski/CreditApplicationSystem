using CreditApplicationSystem.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly CreditApplicationWorkflowDbContext _context;

        public CommandExecutor(CreditApplicationWorkflowDbContext context)
        {
            _context = context;
        }

        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(_context);
        }
    }
}