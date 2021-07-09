using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/credit-applications")]
    public class CreditApplicationsController : ApiControllerBase
    {
        private readonly ILogger<CreditApplicationsController> _logger;

        public CreditApplicationsController(IMediator mediator, ILogger<CreditApplicationsController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetCreditApplications([FromQuery] GetCreditApplicationsRequest request)
        {
            return HandleRequest<GetCreditApplicationsRequest, GetCreditApplicationsResponse>(request);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<IActionResult> GetCreditApplicationById([FromRoute] int id)
        {
            return HandleRequest<GetCreditApplicationByIdRequest, GetCreditApplicationByIdResponse>(
                new GetCreditApplicationByIdRequest { Id = id });
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddCreditApplication([FromBody] AddCreditApplicationRequest request)
        {
            return HandleRequest<AddCreditApplicationRequest, AddCreditApplicationResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> EditCreditApplication([FromBody] EditCreditApplicationRequest request)
        {
            return HandleRequest<EditCreditApplicationRequest, EditCreditApplicationResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteCreditApplication([FromBody] DeleteCreditApplicationRequest request)
        {
            return HandleRequest<DeleteCreditApplicationRequest, DeleteCreditApplicationResponse>(request);
        }
    }
}
