using CreditApplicationSystem.ApplicationServices.API.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/hc")]
    public class HealthChecksController : ControllerBase
    {
        private readonly HttpClient _client = new();

        //public HealthChecksController(HttpClient client)
        //{
        //    _client = client;
        //}

        /// <summary>
        /// Health check endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorModel))]
        public async Task<ActionResult<string>> CheckHealthAsync()
        {
            var url = "https://localhost:5001/api/customers/";
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            var response = await _client.GetAsync(url);
            stopwatch.Stop();

            if (response.IsSuccessStatusCode && stopwatch.ElapsedMilliseconds < 2000)
            {
                return $"Service is running (response: {stopwatch.ElapsedMilliseconds} milliseconds).";
            }
            else if (response.IsSuccessStatusCode)
            {
                return $"Service is running, but performance is degraded (response: {stopwatch.ElapsedMilliseconds} milliseconds).";
            }

            return "Service is not responding correctly";
        }
    }
}