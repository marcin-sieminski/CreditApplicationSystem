using Microsoft.EntityFrameworkCore;

namespace CreditApplicationWorkflow.Mvc.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {
            
        }

        public DbSet<CreditApplication> CreditApplications { get; set; }
    }
}
