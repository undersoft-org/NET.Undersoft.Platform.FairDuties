using System.Series;

namespace Undersoft.AEP
{
    public interface ISequence<TSlot, TAlloc> : ISequence where TSlot : ISlot where TAlloc : IAlloc
    {
        BlocksModel<TSlot, TAlloc> Blocks { get; }

        IDeck<IClaim> Claims { get; set; }

        IDeck<IResource> Resources { get; set; }
    }

    public interface ISequence
    {
        public int FrameOffset { get; set; }

        public int FrameCount { get; set; }

        public int BlockOffset { get; set; }

        public int LastBlockId { get; set; }

        public int LastFrameId { get; set; }

        public int LastSlotId { get; set; }

        public int LastAllocId { get; set; }

        public int LastAllocOrdinal { get; set; }

        public int LastRateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastClaimOrdinal { get; set; }

        IFindable<IAllocModel> Allocs { get; set; }

        IAllocSet AllocSet { get; set; }

        long AllocSetId { get; set; }
    }
}