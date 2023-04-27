using System.Series;

namespace Undersoft.AEP.Core
{
    public class Sectors<TSlot, TUsage> : MassCatalogBase<ISector<TSlot, TUsage>> where TSlot : ISocket where TUsage : IUsage
    {
        public Sectors() { }

        public Sectors(Vector<TSlot, TUsage> vector)
        {
            Vector = vector;
        }

        public Vector<TSlot, TUsage> Vector { get; set; }

        public override ICard<ISector<TSlot, TUsage>> EmptyCard()
        {
            return new Card<ISector<TSlot, TUsage>>();
        }

        public override ICard<ISector<TSlot, TUsage>>[] EmptyCardTable(int size)
        {
            return new Card<ISector<TSlot, TUsage>>[size];
        }

        public override ICard<ISector<TSlot, TUsage>>[] EmptyDeck(int size)
        {
            return new Card<ISector<TSlot, TUsage>>[size];
        }

        public override ICard<ISector<TSlot, TUsage>> NewCard(ulong key, ISector<TSlot, TUsage> value)
        {
            return new Card<ISector<TSlot, TUsage>>(key, assignParentRefs(value));
        }

        public override ICard<ISector<TSlot, TUsage>> NewCard(object key, ISector<TSlot, TUsage> value)
        {
            return new Card<ISector<TSlot, TUsage>>(key, assignParentRefs(value));
        }

        public override ICard<ISector<TSlot, TUsage>> NewCard(ICard<ISector<TSlot, TUsage>> card)
        {
            assignParentRefs(card.Value);
            return new Card<ISector<TSlot, TUsage>>(card);
        }

        public override ICard<ISector<TSlot, TUsage>> NewCard(ISector<TSlot, TUsage> card)
        {
            return new Card<ISector<TSlot, TUsage>>(assignParentRefs(card));
        }

        private ISector<TSlot, TUsage> assignParentRefs(ISector<TSlot, TUsage> value)
        {
            value.Vector = Vector;
            value.Liabilities = new Album<ILiability>(Vector.Liabilities);
            value.Capacity = Vector.UsageSet.BlockCapacity;
            value.Resources = new Album<IResource>(Vector.Resources);
            return value;
        }
    }
}
