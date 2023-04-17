using System.Series;

namespace Undersoft.AEP
{
    public class BlocksModel<TSlot, TAlloc> : MassCatalogBase<BlockModel<TSlot, TAlloc>> where TSlot : ISlot where TAlloc : IAlloc
    {
        public BlocksModel() { }

        public BlocksModel(SequenceModel<TSlot, TAlloc> sequence)
        {
            Sequence = sequence;
        }

        public SequenceModel<TSlot, TAlloc> Sequence { get; set; }

        public override ICard<BlockModel<TSlot, TAlloc>> EmptyCard()
        {
            return new Card<BlockModel<TSlot, TAlloc>>();
        }

        public override ICard<BlockModel<TSlot, TAlloc>>[] EmptyCardTable(int size)
        {
            return new Card<BlockModel<TSlot, TAlloc>>[size];
        }

        public override ICard<BlockModel<TSlot, TAlloc>>[] EmptyDeck(int size)
        {
            return new Card<BlockModel<TSlot, TAlloc>>[size];
        }

        public override ICard<BlockModel<TSlot, TAlloc>> NewCard(ulong key, BlockModel<TSlot, TAlloc> value)
        {
            return new Card<BlockModel<TSlot, TAlloc>>(key, assignParentRefs(value));
        }

        public override ICard<BlockModel<TSlot, TAlloc>> NewCard(object key, BlockModel<TSlot, TAlloc> value)
        {
            return new Card<BlockModel<TSlot, TAlloc>>(key, assignParentRefs(value));
        }

        public override ICard<BlockModel<TSlot, TAlloc>> NewCard(ICard<BlockModel<TSlot, TAlloc>> card)
        {
            assignParentRefs(card.Value);
            return new Card<BlockModel<TSlot, TAlloc>>(card);
        }

        public override ICard<BlockModel<TSlot, TAlloc>> NewCard(BlockModel<TSlot, TAlloc> card)
        {
            return new Card<BlockModel<TSlot, TAlloc>>(assignParentRefs(card));
        }

        private BlockModel<TSlot, TAlloc> assignParentRefs(BlockModel<TSlot, TAlloc> value)
        {
            value.Sequence = Sequence;
            value.Claims = new Album<IClaim>(Sequence.Claims);
            value.Capacity = Sequence.AllocSet.BlockCapacity;
            value.Resources = new Album<IResource>(Sequence.Resources);
            return value;
        }
    }
}
