using CreditApplicationSystem.ApplicationServices.API.Domain.Customer;
using CreditApplicationSystem.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CreditApplicationWorkflow.Mvc.Pages.Customers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGet([FromQuery] GetCustomersRequest request)
        {
            var response = await _mediator.Send(request);
            Customers = response.Data;
        }
    }
}
