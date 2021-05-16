using CreditApplicationSystem.DataAccess.Entities;
using CreditApplicationSystem.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;

        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers() => _repository.GetAll();

        [HttpGet]
        [Route("{id}")]
        public Customer GetCustomerById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
