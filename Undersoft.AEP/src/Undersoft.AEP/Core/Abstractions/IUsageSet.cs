using RadicalR;
using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP.Core
{
    public interface IUsageSet : IIdentifiable
    {
        public float BlockCapacity { get; set; }

        public float SectorCapacity { get; set; }

        public int SectorSize { get; set; }

        public int BlockSize { get; set; }

        public float BlockSeed { get; set; }

        public int LastEstimateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastLiabilityOrdinal { get; set; }

        public long VertexId { get; set; }
        IVertex Vertex { get; }

        IEnumerable<ILink> SourceLinks { get; }

        IEnumerable<ILink> AssetLinks { get; }

        IFindable<IEstimate> Estimates { get; }

        public long SetupId { get; }
        ISetup Setup { get; }
    }
}