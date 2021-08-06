using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace CreditApplicationSystem.ApplicationServices.Helpers
{
    public class UserNameEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserNameEnricher() : this(new HttpContextAccessor())
        {
        }

        public UserNameEnricher(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var userName = _contextAccessor.HttpContext?.User?.Identity?.Name;
            var property = propertyFactory.CreateProperty("UserName", userName);

            logEvent.AddOrUpdateProperty(property);
        }
    }
}
