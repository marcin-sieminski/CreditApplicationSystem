using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;
using CreditApplicationWorkflow.Mvc.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CreditApplicationWorkflow.Mvc.Controllers
{
    [Authorize]
    public class CreditApplicationsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CreditApplicationsController> _logger;

        public CreditApplicationsController(IMediator mediator, ILogger<CreditApplicationsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> Index([FromQuery] GetCreditApplicationsCountRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return View(new HomePageViewModel { ActiveCreditApplicationsNumber = response.Data });
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get credit applications count: {e}");
                return RedirectToAction(nameof(Error));
            }
        }

        public async Task<IActionResult> List([FromQuery] GetCreditApplicationsRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return View(new CreditApplicationListViewModel { CreditApplications = response.Data });
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get credit applications: {e}");
                return RedirectToAction(nameof(Error));
            }
        }

        [Route("{id:int}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetCreditApplicationByIdRequest { Id = id });
                return View(response.Data);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get credit application details: {e}");
                return RedirectToAction(nameof(Error));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
