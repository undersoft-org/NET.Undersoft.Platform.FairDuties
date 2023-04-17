using Undersoft.IDP.Shared.Configuration.Configuration.Identity;

namespace Undersoft.IDP.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}