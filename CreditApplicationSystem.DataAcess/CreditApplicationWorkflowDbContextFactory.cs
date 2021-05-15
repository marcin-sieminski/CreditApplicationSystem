using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CreditApplicationSystem.DataAccess
{
    public class CreditApplicationWorkflowDbContextFactory : IDesignTimeDbContextFactory<CreditApplicationWorkflowDbContext>
    {
        public CreditApplicationWorkflowDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CreditApplicationWorkflowDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=CreditApplicationSystem;Integrated Security=True");

            return new CreditApplicationWorkflowDbContext(optionsBuilder.Options);
        }
    }
}
