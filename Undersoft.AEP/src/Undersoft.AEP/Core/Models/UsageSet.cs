using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP.Core
{
    public class UsageSet : Raw.UsageSet, IUsageSet
    {
        public IVertex Vertex { get; set; }

        public IEnumerable<ILink> SourceLinks { get; set; }

        public IEnumerable<ILink> AssetLinks { get; set; }

        public IEnumerable<ILink> EstimateLinks { get; set; }

        public IFindable<IEstimate> Estimates { get; set; }

        public ISetup Setup { get; set; }
    }
}
