using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.Repositories
{
    public class CreditApplicationRepository : IRepository<CreditApplication>
    {
        protected readonly CreditApplicationWorkflowDbContext context;
        private DbSet<CreditApplication> entities;

        public CreditApplicationRepository(CreditApplicationWorkflowDbContext context)
        {
            this.context = context;
            entities = context.Set<CreditApplication>();
        }

        public Task<List<CreditApplication>> GetAll()
        {
            return entities
                .Include(x => x.Customer)
                .Include(x => x.ApplicationStatus)
                .Include(x => x.Employee)
                .Include(x => x.ProductType)
                .ToListAsync();
        }

        public Task<CreditApplication> GetById(int id)
        {
            return entities
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.ApplicationStatus)
                .Include(x => x.ProductType)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task Insert(CreditApplication entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(CreditApplication entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            return context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            CreditApplication entity = entities.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            return context.SaveChangesAsync();
        }

        public int GetActiveApplicationsNumber { get => entities.Count(x => x.IsActive == true); }
    }
}
