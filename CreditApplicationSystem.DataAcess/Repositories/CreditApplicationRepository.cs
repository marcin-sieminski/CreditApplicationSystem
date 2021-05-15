using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<CreditApplication> GetAll()
        {
            return entities
                .Include(x => x.Customer)
                .Include(x => x.ApplicationStatus)
                .Include(x => x.Employee)
                .Include(x => x.ProductType)
                .AsEnumerable();
        }

        public CreditApplication GetById(int id)
        {
            return entities
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.ApplicationStatus)
                .Include(x => x.ProductType)
                .SingleOrDefault(e => e.Id == id);
        }

        public void Insert(CreditApplication entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(CreditApplication entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            CreditApplication entity = entities.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public int GetActiveApplicationsNumber { get => entities.Count(x => x.IsActive == true); }
    }
}
