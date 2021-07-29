using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ApiControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(IMediator mediator, ILogger<CustomersController> logger) : base(mediator)
        {
            _logger = logger;
            _logger.LogInformation("Customers controller logging.");
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IActionResult> GetCustomers([FromQuery] GetCustomersRequest request)
        {
            return HandleRequest<GetCustomersRequest, GetCustomersResponse>(request);
        }

        /// <summary>
        /// Get scecific customer by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            return HandleRequest<GetCustomerByIdRequest, GetCustomerByIdResponse>(new GetCustomerByIdRequest { Id = id });
        }

        /// <summary>
        /// Create new customer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            return HandleRequest<AddCustomerRequest, AddCustomerResponse>(request);
        }

        /// <summary>
        /// Edit data of an existing customer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> EditCustomer([FromBody] EditCustomerRequest request)
        {
            return HandleRequest<EditCustomerRequest, EditCustomerResponse>(request);
        }

        /// <summary>
        /// Delete customer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerRequest request)
        {
            return HandleRequest<DeleteCustomerRequest, DeleteCustomerResponse>(request);
        }
    }
}
