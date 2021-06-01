using CreditApplicationSystem.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command);
    }
}