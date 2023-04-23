using RadicalR;
using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP.Core
{
    public interface ISourceProxy : IIdentifiable
    {
        IFindable<IEstimate> Estimates { get; }
        IUsageSet UsageSet { get; }
        IEnumerable<ILink> AssetLinks { get; }
        IDeck<IAsset> Assets { get; }
        ISource Source { get; set; }
        ISetup Setup { get; }
        long SetupId { get; }
        IDeck<IResource> Resources { get; }
    }
}