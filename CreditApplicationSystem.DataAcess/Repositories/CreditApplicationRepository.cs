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
        private readonly CreditApplicationWorkflowDbContext _context;
        private readonly DbSet<CreditApplication> _entities;

        public CreditApplicationRepository(CreditApplicationWorkflowDbContext context)
        {
            _context = context;
            _entities = context.Set<CreditApplication>();
        }

        public Task<List<CreditApplication>> GetAll()
        {
            return _entities
                .Include(x => x.Customer)
                .Include(x => x.ApplicationStatus)
                .Include(x => x.Employee)
                .Include(x => x.ProductType)
                .ToListAsync();
        }

        public Task<CreditApplication> GetById(int id)
        {
            return _entities
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

            _entities.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(CreditApplication entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Update(entity);
            return _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            CreditApplication entity = _entities.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public int GetActiveApplicationsNumber { get => _entities.Count(x => x.IsActive == true); }
    }
}
