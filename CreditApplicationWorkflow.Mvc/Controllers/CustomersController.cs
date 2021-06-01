using Microsoft.AspNetCore.Mvc;

namespace CreditApplicationWorkflow.Mvc.Controllers
{
    public class CustomersController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}