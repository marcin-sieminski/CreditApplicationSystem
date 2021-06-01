using CreditApplicationSystem.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
