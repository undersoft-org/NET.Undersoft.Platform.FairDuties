using System.Series;

namespace Undersoft.AEP.Core
{
    public class Sectors<TSlot, TUsage> : MassCatalogBase<Sector<TSlot, TUsage>> where TSlot : ISocket where TUsage : IUsage
    {
        public Sectors() { }

        public Sectors(Vector<TSlot, TUsage> vector)
        {
            Vector = vector;
        }

        public Vector<TSlot, TUsage> Vector { get; set; }

        public override ICard<Sector<TSlot, TUsage>> EmptyCard()
        {
            return new Card<Sector<TSlot, TUsage>>();
        }

        public override ICard<Sector<TSlot, TUsage>>[] EmptyCardTable(int size)
        {
            return new Card<Sector<TSlot, TUsage>>[size];
        }

        public override ICard<Sector<TSlot, TUsage>>[] EmptyDeck(int size)
        {
            return new Card<Sector<TSlot, TUsage>>[size];
        }

        public override ICard<Sector<TSlot, TUsage>> NewCard(ulong key, Sector<TSlot, TUsage> value)
        {
            return new Card<Sector<TSlot, TUsage>>(key, assignParentRefs(value));
        }

        public override ICard<Sector<TSlot, TUsage>> NewCard(object key, Sector<TSlot, TUsage> value)
        {
            return new Card<Sector<TSlot, TUsage>>(key, assignParentRefs(value));
        }

        public override ICard<Sector<TSlot, TUsage>> NewCard(ICard<Sector<TSlot, TUsage>> card)
        {
            assignParentRefs(card.Value);
            return new Card<Sector<TSlot, TUsage>>(card);
        }

        public override ICard<Sector<TSlot, TUsage>> NewCard(Sector<TSlot, TUsage> card)
        {
            return new Card<Sector<TSlot, TUsage>>(assignParentRefs(card));
        }

        private Sector<TSlot, TUsage> assignParentRefs(Sector<TSlot, TUsage> value)
        {
            value.Vector = Vector;
            value.Liabilities = new Album<ILiability>(Vector.Liabilities);
            value.Capacity = Vector.UsageSet.BlockCapacity;
            value.Resources = new Album<IResource>(Vector.Resources);
            return value;
        }
    }
}
