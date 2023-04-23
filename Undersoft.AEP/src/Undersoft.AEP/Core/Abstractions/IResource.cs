using RadicalR;

namespace Undersoft.AEP.Core
{
    public interface IResource : IIdentifiable
    {
        IAsset Asset { get; set; }

        IEstimate Estimate { get; set; }

        IUsageSet UsageSet { get; set; }

        ISource Source { get; set; }
    }
}