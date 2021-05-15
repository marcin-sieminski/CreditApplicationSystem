using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
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
            T entity = entities.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
