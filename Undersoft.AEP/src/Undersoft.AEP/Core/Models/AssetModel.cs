using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP
{
    public class AssetModel : Asset, IAsset
    {
        public IFindable<IAllocRate> AllocRates { get; }

        public IEnumerable<ILink> AllocTypeLinks { get; }

        public IConfiguration Configuration { get; }
    }
}
