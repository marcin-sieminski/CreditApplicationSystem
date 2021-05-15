using CreditApplicationSystem.DataAccess.Entities;
using System.Collections.Generic;

namespace CreditApplicationSystem.DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
