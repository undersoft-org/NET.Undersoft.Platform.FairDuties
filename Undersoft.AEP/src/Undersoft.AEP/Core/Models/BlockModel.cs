using System.Series;

namespace Undersoft.AEP
{
    public class BlockModel<TSlot, TAlloc> : CatalogBase<FrameModel<TSlot, TAlloc>> where TSlot : ISlot where TAlloc : IAlloc
    {
        public BlockModel() { }

        public float Capacity { get; set; }

        public SequenceModel<TSlot, TAlloc> Sequence { get; set; }

        public IDeck<IAlloc> Allocs { get; set; }

        public IDeck<IClaim> Claims { get; set; }

        public IDeck<IResource> Resources { get; set; }

        public override ICard<FrameModel<TSlot, TAlloc>> NewCard(ulong key, FrameModel<TSlot, TAlloc> value)
        {
            return new Card<FrameModel<TSlot, TAlloc>>(key, assignParentRefs(value));
        }

        public override ICard<FrameModel<TSlot, TAlloc>> NewCard(object key, FrameModel<TSlot, TAlloc> value)
        {
            return new Card<FrameModel<TSlot, TAlloc>>(key, assignParentRefs(value));
        }

        public override ICard<FrameModel<TSlot, TAlloc>> NewCard(ICard<FrameModel<TSlot, TAlloc>> card)
        {
            assignParentRefs(card.Value);
            return new Card<FrameModel<TSlot, TAlloc>>(card);
        }

        public override ICard<FrameModel<TSlot, TAlloc>> NewCard(FrameModel<TSlot, TAlloc> card)
        {
            return new Card<FrameModel<TSlot, TAlloc>>(assignParentRefs(card));
        }

        private FrameModel<TSlot, TAlloc> assignParentRefs(FrameModel<TSlot, TAlloc> value)
        {
            value.Sequence = Sequence;
            value.Claims = new Album<IClaim>(Sequence.Claims);
            value.Capacity = Sequence.AllocSet.FrameCapacity;
            value.Resources = new Album<IResource>(Sequence.Resources);
            return value;
        }
    }
}
