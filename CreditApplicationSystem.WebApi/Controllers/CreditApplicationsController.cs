using CreditApplicationSystem.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCreditApplications([FromQuery] GetCreditApplicationsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCreditApplicationById([FromQuery] GetCreditApplicationByIdRequest request, [FromRoute] int id)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
