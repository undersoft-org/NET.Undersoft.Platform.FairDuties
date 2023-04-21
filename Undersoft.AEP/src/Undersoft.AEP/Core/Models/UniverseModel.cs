using System.Series;

namespace Undersoft.AEP
{
    public class UniverseModel<TSlot, TAlloc> : MassCatalog<SequenceModel<TSlot, TAlloc>>, IUniverse
        where TSlot : SlotModel
        where TAlloc : IAlloc
    {
        public long Id
        {
            get => (long)UniqueKey;
            set => UniqueKey = (ulong)value;
        }

        public string Name { get; set; }

        public int LastRateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastClaimOrdinal { get; set; }

        public IFindable<IAllocSet> AllocSets { get; set; }

        public IFindable<IAllocType> AllocTypes { get; set; }

        public IFindable<IAsset> Assets { get; set; }

        public IConfiguration Configuration { get; set; }

        public long? ConfigurationId { get; set; }
    }
}
