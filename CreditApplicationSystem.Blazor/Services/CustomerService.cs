using CreditApplicationSystem.Blazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpService _service;

        public CustomerService(IHttpService service)
        {
            _service = service;
        }

        public async Task<int> Create(Customer customer)
        {
            var result = await _service.Post<Customer>("/customers", customer);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _service.Delete($"/customers/{id}");
            return id;
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            return _service.Get<IEnumerable<Customer>>("/customers");
        }

        public Task<Customer> GetById(int id)
        {
            return _service.Get<Customer>($"/customers/{id}");
        }

        public async Task<int> Update(Customer customer)
        {
            var result = await _service.Put<Customer>($"/customers/{customer.Id}", customer);
            return result.Id;
        }
    }
}
