using System.Series;

namespace Undersoft.AEP.Core
{
    public class Vector<TSocket, TUsage> : Spectrum<IUsage>, IUnique, IVector<TSocket, TUsage>
        where TSocket : ISocket where TUsage : IUsage
    {
        public IMassDeck<ISector<TSocket, TUsage>> Sectors { get; set; }

        public Vector(IVector vector)
            : this(vector.UsageSet, vector.SectorOffset, vector.BlockOffset, vector.BlockCount)
        {
            ((IDeck<IUsage>)Usages).Put(vector.Usages);
        }

        public Vector(IUsageSet allocSet, int sectorOffset, int blockOffset, int blockCount)
            : base(100 * 1000, true)
        {
            BlockOffset = blockOffset;
            BlockCount = blockCount;
            SectorOffset = sectorOffset;
            var proxy = new UsageSetProxy(allocSet.Id, allocSet.Vertex);
            UsageSet = proxy;
            UsageSetId = allocSet.Id;
            UniqueKey = (ulong)allocSet.Id;
            LastSectorId = SectorOffset;
            LastBlockId = (int)(SectorOffset * UsageSet.BlockCapacity);
            SectorCount = (int)Math.Ceiling((BlockCount + BlockOffset) / (double)UsageSet.SectorSize);
            Liabilities = proxy.Liabilities;
            Resources = proxy.Resources;
            Resources.ForEach(x => x.Ordinal = LastResourceOrdinal++).Commit();
            Sectors = new Sectors<TSocket, TUsage>(this);
            Usages = new Catalog<IUsage>();
        }

        public int BlockOffset { get; set; }

        public int BlockCount { get; set; }

        public int SectorOffset { get; set; }

        public int SectorCount { get; set; }

        public int LastSectorId { get; set; }

        public int LastBlockId { get; set; }

        public int LastSocketId { get; set; }

        public int LastUsageId { get; set; }

        public int LastAssetOrdinal { get; set; }

        public int LastEstimateOrdinal { get; set; }

        public long UsageSetId { get; set; }

        public IUsageSet UsageSet { get; set; }

        public IFindable<IUsage> Usages { get; set; }

        public IDeck<ILiability> Liabilities { get; set; }

        public int LastLiabilityOrdinal { get; set; }

        public IDeck<IResource> Resources { get; set; }

        public int LastResourceOrdinal { get; set; }

    }
}
