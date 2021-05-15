using CreditApplicationSystem.DataAccess.Entities;
using CreditApplicationSystem.DataAccess.Repositories;
using CreditApplicationWorkflow.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace CreditApplicationWorkflow.Mvc.Controllers
{
    public class CreditApplicationController : Controller
    {
        private readonly ILogger<CreditApplicationController> _logger;
        private readonly IRepository<CreditApplication> _creditApplicationRepository;

        public CreditApplicationController(ILogger<CreditApplicationController> logger, IRepository<CreditApplication> creditApplicationRepository)
        {
            _logger = logger;
            _creditApplicationRepository = creditApplicationRepository;
        }

        public IActionResult Index()
        {
            return View(new HomePageViewModel{ActiveCreditApplicationsNumber = _creditApplicationRepository.GetAll().Count()});
        }

        public IActionResult List()
        {
            return View(new CreditApplicationListViewModel{CreditApplications = _creditApplicationRepository.GetAll()});
        }

        public IActionResult Details(int id)
        {
            return View(_creditApplicationRepository.GetById(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
