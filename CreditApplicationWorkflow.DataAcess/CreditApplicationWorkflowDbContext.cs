using CreditApplicationWorkflow.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditApplicationWorkflow.DataAccess
{
    public class CreditApplicationWorkflowDbContext : DbContext
    {
        public CreditApplicationWorkflowDbContext(DbContextOptions<CreditApplicationWorkflowDbContext> options) : base(options)
        {
            
        }


        public DbSet<CreditApplication> CreditApplications { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
