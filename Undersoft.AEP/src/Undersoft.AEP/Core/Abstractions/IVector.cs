using System.Series;

namespace Undersoft.AEP.Core
{
    public interface IVector<TSocket, TUsage> : IVector where TSocket : ISocket where TUsage : IUsage
    {
        IMassDeck<ISector<TSocket, TUsage>> Sectors { get; }

        IDeck<ILiability> Liabilities { get; set; }

        IDeck<IResource> Resources { get; set; }
    }

    public interface IVector
    {
        public int BlockOffset { get; set; }

        public int BlockCount { get; set; }

        public int SectorOffset { get; set; }

        public int LastSectorId { get; set; }

        public int LastBlockId { get; set; }

        public int LastSocketId { get; set; }

        public int LastUsageId { get; set; }

        public int LastLiabilityOrdinal { get; set; }

        public int LastEstimateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastAssetOrdinal { get; set; }

        IFindable<IUsage> Usages { get; set; }

        IUsageSet UsageSet { get; set; }

        long UsageSetId { get; set; }
    }
}