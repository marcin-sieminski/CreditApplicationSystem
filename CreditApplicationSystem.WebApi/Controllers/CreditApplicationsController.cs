using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/credit-applications")]
    public class CreditApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CreditApplicationsController> _logger;

        public CreditApplicationsController(IMediator mediator, ILogger<CreditApplicationsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCreditApplications([FromQuery] GetCreditApplicationsRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get credit applications: {e}");
                return BadRequest("Failed to get credit applications");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCreditApplicationById([FromRoute] int id)
        {
            try
            {
                var request = new GetCreditApplicationByIdRequest()
                {
                    Id = id
                };
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get credit application: {e}");
                return BadRequest("Failed to get credit application");
            }
        }
    }
}
