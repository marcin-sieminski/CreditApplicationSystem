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

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IActionResult> GetCustomers([FromQuery] GetCustomersRequest request)
        {
            return HandleRequest<GetCustomersRequest, GetCustomersResponse>(request);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            return HandleRequest<GetCustomerByIdRequest, GetCustomerByIdResponse>(new GetCustomerByIdRequest { Id = id });
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            return HandleRequest<AddCustomerRequest, AddCustomerResponse>(request);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> EditCustomer([FromBody] EditCustomerRequest request)
        {
            return HandleRequest<EditCustomerRequest, EditCustomerResponse>(request);
        }

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
