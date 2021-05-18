using CreditApplicationSystem.DataAccess.Entities;
using CreditApplicationSystem.DataAccess.Repositories;
using CreditApplicationWorkflow.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplicationWorkflow.Mvc.Controllers
{
    [Authorize]
    public class CreditApplicationController : Controller
    {
        private readonly ILogger<CreditApplicationController> _logger;
        private readonly IRepository<CreditApplication> _creditApplicationRepository;

        public CreditApplicationController(ILogger<CreditApplicationController> logger, IRepository<CreditApplication> creditApplicationRepository)
        {
            _logger = logger;
            _creditApplicationRepository = creditApplicationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _creditApplicationRepository.GetAll();
            return View(new HomePageViewModel{ActiveCreditApplicationsNumber = result.Count()});
        }

        public async Task<IActionResult> List()
        {
            return View(new CreditApplicationListViewModel{CreditApplications = await _creditApplicationRepository.GetAll()});
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _creditApplicationRepository.GetById(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
