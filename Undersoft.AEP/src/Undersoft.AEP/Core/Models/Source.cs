using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP.Core
{
    public class Source : Raw.Source, ISource
    {
        public IFindable<IEstimate> Estimates { get; }

        public IEnumerable<ILink> AssetLinks { get; }

        public ISetup Setup { get; }
    }
}
