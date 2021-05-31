using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationWorkflow.Mvc.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CreditApplicationWorkflow.Mvc.Controllers
{
    [Authorize]
    public class CreditApplicationsController : Controller
    {
        private readonly IMediator _mediator;
        //private readonly IRepository<CreditApplication> _creditApplicationRepository;

        public CreditApplicationsController(IMediator mediator)
        {
            //_creditApplicationRepository = creditApplicationRepository;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index([FromQuery] GetCreditApplicationsCountRequest request)
        {
            var response = await _mediator.Send(request);
            return View(new HomePageViewModel{ActiveCreditApplicationsNumber = response.Data});
        }

        public async Task<IActionResult> List([FromQuery] GetCreditApplicationsRequest request)
        {
            var response = await _mediator.Send(request);
            return View(new CreditApplicationListViewModel{CreditApplications = response.Data});
        }

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
