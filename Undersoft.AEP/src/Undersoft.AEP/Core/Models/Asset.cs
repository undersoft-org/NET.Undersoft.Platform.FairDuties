using System.Instant.Linking;

namespace Undersoft.AEP.Core
{
    public class Asset : Raw.Asset, IAsset
    {
        public IEnumerable<ILink> RelatedTo { get; }

        public IEnumerable<ILink> OptionalTo { get; }

        public IEnumerable<ILink> DependentOn { get; }
    }
}
