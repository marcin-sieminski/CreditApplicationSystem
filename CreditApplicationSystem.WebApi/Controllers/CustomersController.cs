using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(IMediator mediator, ILogger<CustomersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCustomers([FromQuery] GetCustomersRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get customers: {e}");
                return BadRequest("Failed to get customers");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            try
            {
                var request = new GetCustomerByIdRequest()
                {
                    Id = id
                };
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get customer: {e}");
                return NotFound("Failed to get customer");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to add customer: {e}");
                return BadRequest("Failed to add customer");
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditCustomer([FromBody] EditCustomerRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to edit customer: {e}");
                return BadRequest("Failed to edit customer");
            }
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to delete customer: {e}");
                return BadRequest("Failed to delete customer");
            }
        }
    }
}
