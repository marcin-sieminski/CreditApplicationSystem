using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetCustomersRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomerById()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
