using Serilog;
using Serilog.Configuration;
using System;

namespace CreditApplicationSystem.ApplicationServices.Helpers
{
     public static class UserNameLoggerConfigurationExtensions
    {
        public static LoggerConfiguration WithUserName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<UserNameEnricher>();
        }
    }
}
