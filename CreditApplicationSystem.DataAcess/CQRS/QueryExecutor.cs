using CreditApplicationSystem.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly CreditApplicationWorkflowDbContext _context;

        public QueryExecutor(CreditApplicationWorkflowDbContext context)
        {
            _context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }
    }
}