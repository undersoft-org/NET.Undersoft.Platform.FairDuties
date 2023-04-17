using Undersoft.IDP.Shared.Configuration.Configuration.Identity;
using Undersoft.IDP.STS.Identity.Configuration.Interfaces;

namespace Undersoft.IDP.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}