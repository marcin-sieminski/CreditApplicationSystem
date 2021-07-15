using CreditApplicationSystem.Blazor.Models;
using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor.Services
{
    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}