using System.Series;

namespace Undersoft.AEP.Core
{
    public class Sector<TSlot, TUsage> : CatalogBase<Block<TSlot, TUsage>>, ISector<TSlot, TUsage> where TSlot : ISocket where TUsage : IUsage
    {
        public Sector() { }

        public float Capacity { get; set; }

        public IVector<TSlot, TUsage> Vector { get; set; }

        public IDeck<IUsage> Usages { get; set; }

        public IDeck<ILiability> Liabilities { get; set; }

        public IDeck<IResource> Resources { get; set; }

        public override ICard<Block<TSlot, TUsage>> NewCard(ulong key, Block<TSlot, TUsage> value)
        {
            return new Card<Block<TSlot, TUsage>>(key, assignParentRefs(value));
        }

        public override ICard<Block<TSlot, TUsage>> NewCard(object key, Block<TSlot, TUsage> value)
        {
            return new Card<Block<TSlot, TUsage>>(key, assignParentRefs(value));
        }

        public override ICard<Block<TSlot, TUsage>> NewCard(ICard<Block<TSlot, TUsage>> card)
        {
            assignParentRefs(card.Value);
            return new Card<Block<TSlot, TUsage>>(card);
        }

        public override ICard<Block<TSlot, TUsage>> NewCard(Block<TSlot, TUsage> card)
        {
            return new Card<Block<TSlot, TUsage>>(assignParentRefs(card));
        }

        private Block<TSlot, TUsage> assignParentRefs(Block<TSlot, TUsage> value)
        {
            value.Vector = Vector;
            value.Liabilities = new Album<ILiability>(Vector.Liabilities);
            value.Capacity = Vector.UsageSet.BlockCapacity;
            value.Resources = new Album<IResource>(Vector.Resources);
            return value;
        }
    }
}
