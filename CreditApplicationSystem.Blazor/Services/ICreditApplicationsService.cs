using CreditApplicationSystem.Blazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor.Services
{
    public interface ICreditApplicationService
    {
        Task<IEnumerable<CreditApplication>> GetAll();
        Task<CreditApplication> GetById(int id);
        Task<int> Create(CreditApplication creditApplication);
        Task<int> Delete(int id);
        Task<int> Update(CreditApplication creditApplication);
    }
}