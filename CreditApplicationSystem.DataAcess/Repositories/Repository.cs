using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly CreditApplicationWorkflowDbContext context;
        private DbSet<T> entities;

        public Repository(CreditApplicationWorkflowDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
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
            T entity = entities.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            return context.SaveChangesAsync();
        }
    }
}
