using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess
{
    public class CreditApplicationWorkflowDbContext : IdentityDbContext
    {
        public CreditApplicationWorkflowDbContext()
        {
            
        }

        public CreditApplicationWorkflowDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CreditApplicationSystem;Integrated Security=True");
            }
        }

        public DbSet<CreditApplication> CreditApplications { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           // seed data
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                CustomerFirstName = "Anna",
                CustomerLastName = "Cabacka"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 2,
                CustomerFirstName = "Marcin",
                CustomerLastName = "Kowalski"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                DepartmentName = "Control"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Abacki",
                DepartmentId = 1
            });

            modelBuilder.Entity<ProductType>().HasData(new ProductType()
            {
                Id = 1,
                ProductTypeName = "Overdraft"
            });

            modelBuilder.Entity<ApplicationStatus>().HasData(new ApplicationStatus()
            {
                Id = 1,
                ApplicationStatusName = "Initial check"
            });

            modelBuilder.Entity<CreditApplication>().HasData(new CreditApplication
            {
                Id = 1, 
                DateOfSubmission = DateTime.Today,
                CustomerId = 1,
                ProductTypeId = 1,
                AmountRequested = 100000M,
                AmountGranted = 50000M,
                ApplicationStatusId = 1,
                DateOfLastStatusChange = DateTime.Today,
                EmployeeId = 1,
                Notes = string.Empty,
                IsActive = true
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.UtcNow;
                        entry.Entity.Inactivated = DateTime.UtcNow;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
