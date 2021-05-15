using CreditApplicationWorkflow.Mvc.Repositories;
using CreditApplicationWorkflow.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CreditApplicationWorkflow.Mvc.Controllers
{
    public class CreditApplicationController : Controller
    {
        private readonly ILogger<CreditApplicationController> _logger;
        private readonly ICreditApplicationRepository _creditApplicationRepository;

        public CreditApplicationController(ILogger<CreditApplicationController> logger, ICreditApplicationRepository creditApplicationRepository)
        {
            _logger = logger;
            _creditApplicationRepository = creditApplicationRepository;
        }

        public IActionResult Index()
        {
            return View(new HomePageViewModel(){ActiveCreditApplicationsNumber = _creditApplicationRepository.GetActiveApplicationsNumber});
        }

        public IActionResult List()
        {
            var model = new CreditApplicationListViewModel{CreditApplications = _creditApplicationRepository.GetAllCreditApplications};
            return View(model);
        }

        public IActionResult Details(int id)
        {
            return View(_creditApplicationRepository.GetCreditApplicationById(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
