using System.Collections.Generic;

namespace CreditApplicationSystem.ApplicationServices.Components.ScopeInformation
{
    public interface IScopeInformation
    {
        Dictionary<string, string> HostScopeInfo { get; }
    }
}
