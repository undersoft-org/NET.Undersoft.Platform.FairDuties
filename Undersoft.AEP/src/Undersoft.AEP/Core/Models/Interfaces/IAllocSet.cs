using System.Instant.Linking;
using System.Series;
using RadicalR;

namespace Undersoft.AEP
{
    public interface IAllocSet : IIdentifiable
    {
        public float FrameCapacity { get; set; }

        public float BlockCapacity { get; set; }

        public int FrameSize { get; set; }

        public int BlockSize { get; set; }

        public float FrameSeed { get; set; }

        public int LastRateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastClaimOrdinal { get; set; }

        public long UniverseId { get; set; }
        IUniverse Universe { get; }

        IEnumerable<ILink> AssetLinks { get; }

        IEnumerable<ILink> AllocTypeLinks { get; }

        IFindable<IAllocRate> AllocRates { get; }

        public long ConfigurationId { get; }
        IConfiguration Configuration { get; }
    }
}