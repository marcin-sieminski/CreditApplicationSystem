using CreditApplicationSystem.Blazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
    }
}