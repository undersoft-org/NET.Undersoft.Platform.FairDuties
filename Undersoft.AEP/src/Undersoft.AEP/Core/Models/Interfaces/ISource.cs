using RadicalR;
using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP.Core
{
    public interface ISource : IIdentifiable
    {
        public int LastEstimateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        IFindable<IEstimate> Estimates { get; }

        IEnumerable<ILink> AssetLinks { get; }

        long SetupId { get; }
        ISetup Setup { get; }
    }
}