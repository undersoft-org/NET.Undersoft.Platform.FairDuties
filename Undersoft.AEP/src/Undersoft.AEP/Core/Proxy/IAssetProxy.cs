using System.Instant.Linking;
using System.Series;
using RadicalR;

namespace Undersoft.AEP
{
    public interface IAssetProxy : IIdentifiable
    {
        IFindable<IAllocRate> AllocRates { get; }
        IAllocSet AllocSet { get; }
        IEnumerable<ILink> AllocTypeLinks { get; }
        IDeck<IAllocType> AllocTypes { get; }
        IAsset Asset { get; set; }
        IConfiguration Configuration { get; }
        long ConfigurationId { get; }
        IDeck<IResource> Resources { get; }
    }
}