namespace System.Instant.Relationing
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Series;
    using System.Uniques;

    public enum RelationSite
    {
        None,
        Origin,
        Target,
        Node
    }

    public class Relations : CatalogBase<Relation>, IUnique
    {
        private new Uscn serialcode;

        public Relations() { }

        public Relations(IList<Relation> links)
        {
            Add(links);
        }

        public Relation this[string linkName]
        {
            get { return base[linkName]; }
            set { base[linkName] = value; }
        }
        public new Relation this[int linkid]
        {
            get { return base[linkid]; }
            set { base[linkid] = value; }
        }

        public Relation TargetRelation(string TargetName)
        {
            return AsValues().Where(o => o.TargetName.Equals(TargetName)).FirstOrDefault();
        }

        public Relation OriginRelation(string OriginName)
        {
            return AsValues().Where(o => o.OriginName.Equals(OriginName)).FirstOrDefault();
        }

        public RelationMember TargetMember(string TargetName)
        {
            Relation link = TargetRelation(TargetName);
            if (link != null)
                return link.Target;
            return null;
        }

        public RelationMember OriginMember(string OriginName)
        {
            Relation link = OriginRelation(OriginName);
            if (link != null)
                return link.Origin;
            return null;
        }

        public override ICard<Relation> EmptyCard()
        {
            return new Card<Relation>();
        }

        public override ICard<Relation> NewCard(ulong key, Relation value)
        {
            return new Card<Relation>(key, value);
        }

        public override ICard<Relation> NewCard(object key, Relation value)
        {
            return new Card<Relation>(key, value);
        }

        public override ICard<Relation> NewCard(ICard<Relation> value)
        {
            return new Card<Relation>(value);
        }

        public override ICard<Relation> NewCard(Relation value)
        {
            return new Card<Relation>(value);
        }

        public override ICard<Relation>[] EmptyCardTable(int size)
        {
            return new Card<Relation>[size];
        }

        public override ICard<Relation>[] EmptyDeck(int size)
        {
            return new Card<Relation>[size];
        }

        protected override bool InnerAdd(Relation value)
        {
            return InnerAdd(NewCard(value));
        }

        protected override ICard<Relation> InnerPut(Relation value)
        {
            return InnerPut(NewCard(value));
        }

        public Uscn SerialCode
        {
            get => serialcode;
            set => serialcode = value;
        }

        public new IUnique Empty => Uscn.Empty;

        public override ulong UniqueKey
        {
            get => serialcode.UniqueKey;
            set => serialcode.UniqueKey = value;
        }

        public override ulong UniqueType
        {
            get => serialcode.UniqueType;
            set => serialcode.UniqueType = value;
        }

        public override int CompareTo(IUnique other)
        {
            return serialcode.CompareTo(other);
        }

        public override bool Equals(IUnique other)
        {
            return serialcode.Equals(other);
        }

        public override byte[] GetBytes()
        {
            return serialcode.GetBytes();
        }

        public override byte[] GetUniqueBytes()
        {
            return serialcode.GetUniqueBytes();
        }
    }
}
