using CreditApplicationSystem.Blazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<int> Create(Customer customer);
        Task<int> Delete(int id);
        Task<int> Update(Customer customer);
    }
}
