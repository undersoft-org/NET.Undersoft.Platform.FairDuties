using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP.Core
{
    public class Source : Raw.Source, ISource
    {
        public IFindable<IEstimate> Estimates { get; set; }

        public IEnumerable<ILink> AssetLinks { get; set; }

        public ISetup Setup { get; set; }
    }
}
