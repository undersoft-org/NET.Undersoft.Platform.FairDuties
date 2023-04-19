using System.Series;

namespace Undersoft.AEP
{
    public class SequenceModel<TSlot, TAlloc> : Spectrum<IAlloc>, IUnique, ISequence<TSlot, TAlloc>
        where TSlot : ISlot where TAlloc : IAlloc
    {
        public BlocksModel<TSlot, TAlloc> Blocks { get; set; }

        public SequenceModel(ISequence sequence)
            : this(sequence.AllocSet, sequence.BlockOffset, sequence.FrameOffset, sequence.FrameCount)
        {
            ((IDeck<IAlloc>)Allocs).Put(sequence.Allocs);
        }

        public SequenceModel(IAllocSet allocSet, int blockOffset, int frameOffset, int frameCount)
            : base(100 * 1000, true)
        {
            FrameOffset = frameOffset;
            FrameCount = frameCount;
            BlockOffset = blockOffset;
            var proxy = new AllocSetProxy(allocSet.Id, allocSet.Universe);
            AllocSet = proxy;
            AllocSetId = allocSet.Id;
            UniqueKey = (ulong)allocSet.Id;
            LastFrameId = BlockOffset;
            LastSlotId = (int)(BlockOffset * AllocSet.FrameCapacity);
            BlockCount = (int)Math.Ceiling((FrameCount + BlockOffset) / (double)AllocSet.BlockSize);
            Claims = proxy.Claims;
            Resources = proxy.Resources;
            Resources.ForEach(x => x.Ordinal = LastResourceOrdinal++).Commit();
            Blocks = new BlocksModel<TSlot, TAlloc>(this);
            Allocs = new Catalog<IAllocModel>();
        }

        public int FrameOffset { get; set; }

        public int FrameCount { get; set; }

        public int BlockOffset { get; set; }

        public int BlockCount { get; set; }

        public int LastBlockId { get; set; }

        public int LastFrameId { get; set; }

        public int LastSlotId { get; set; }

        public int LastAllocId { get; set; }

        public int LastAllocOrdinal { get; set; }

        public int LastRateOrdinal { get; set; }

        public long AllocSetId { get; set; }

        public IAllocSet AllocSet { get; set; }

        public IFindable<IAllocModel> Allocs { get; set; }

        public IDeck<IClaim> Claims { get; set; }

        public int LastClaimOrdinal { get; set; }

        public IDeck<IResource> Resources { get; set; }

        public int LastResourceOrdinal { get; set; }
    }
}
