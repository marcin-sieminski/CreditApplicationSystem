using CreditApplicationWorkflow.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CreditApplicationWorkflow.Mvc.Controllers
{
    public class CreditApplicationController : Controller
    {
        private readonly ILogger<CreditApplicationController> _logger;

        public CreditApplicationController(ILogger<CreditApplicationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var model = new CreditApplicationListViewModel{CreditApplications = null};
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
