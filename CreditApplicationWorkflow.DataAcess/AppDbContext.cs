using CreditApplicationWorkflow.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditApplicationWorkflow.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {
            
        }

        public DbSet<CreditApplication> CreditApplications { get; set; }
    }
}
