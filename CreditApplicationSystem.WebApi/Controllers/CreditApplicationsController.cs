using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.DataAccess.Entities;
using CreditApplicationSystem.DataAccess.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditApplicationsController : ControllerBase
    {
        private readonly IRepository<CreditApplication>  _creditApplicationRepository;
        private readonly IMediator _mediator;

        public CreditApplicationsController(IRepository<CreditApplication> creditApplicationRepository, IMediator mediator)
        {
            _creditApplicationRepository = creditApplicationRepository;
            _mediator = mediator;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCreditApplications([FromQuery] GetCreditApplicationsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
