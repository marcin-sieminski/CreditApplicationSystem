using System;
using System.Collections.Generic;
using System.Reflection;

namespace CreditApplicationSystem.ApplicationServices.Components.ScopeInformation
{
    public class ScopeInformation : IScopeInformation
    {
        public ScopeInformation()
        {
            HostScopeInfo = new Dictionary<string, string>
            {
                {"MachineName", Environment.MachineName },
                {"EntryPoint", Assembly.GetEntryAssembly().GetName().Name }
            };
        }

        public Dictionary<string, string> HostScopeInfo { get; }
    }
}
