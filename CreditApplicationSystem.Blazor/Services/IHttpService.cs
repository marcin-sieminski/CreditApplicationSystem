using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor.Services
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
        Task<T> Put<T>(string uri, object value);
        Task Delete(string uri);
    }
}