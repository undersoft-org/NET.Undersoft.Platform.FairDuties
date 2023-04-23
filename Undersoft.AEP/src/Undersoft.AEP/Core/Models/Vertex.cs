using System.Series;

namespace Undersoft.AEP.Core
{
    public class Vertex<TSlot, TUsage> : MassCatalog<Vector<TSlot, TUsage>>, IVertex
        where TSlot : Socket
        where TUsage : IUsage
    {
        public long Id
        {
            get => (long)UniqueKey;
            set => UniqueKey = (ulong)value;
        }

        public string Name { get; set; }

        public int LastEstimateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastLiabilityOrdinal { get; set; }

        public IFindable<IUsageSet> UsageSets { get; set; }

        public IFindable<IAsset> Assets { get; set; }

        public IFindable<ISource> Sources { get; set; }

        public ISetup Setup { get; set; }

        public long? SetupId { get; set; }
    }
}
