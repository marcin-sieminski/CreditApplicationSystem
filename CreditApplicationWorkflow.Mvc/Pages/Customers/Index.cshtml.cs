using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using CreditApplicationSystem.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationWorkflow.Mvc.Pages.Customers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IMediator mediator, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public List<Customer> Customers { get; private set; }

        public async Task OnGet([FromQuery] GetCustomersRequest request)
        {
            var response = await _mediator.Send(request);
            Customers = response.Data;

            _logger.LogInformation($"Requested customers.");
        }
    }
}
